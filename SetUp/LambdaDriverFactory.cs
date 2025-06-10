using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace SetUp
{
    public static class LambdaDriverFactory
    {
        private static readonly string gridURL = "@hub.lambdatest.com/wd/hub";
        private static readonly string LT_USERNAME = Environment.GetEnvironmentVariable("LT_USERNAME");
        private static readonly string LT_ACCESS_KEY = Environment.GetEnvironmentVariable("LT_ACCESS_KEY");

        public static IWebDriver CreateDriver(
            string browser = "Chrome",
            string platform = "Windows 10",
            string build = "Selenium CSharp",
            string project = "Default Project")
        {
            dynamic options;

            switch (browser.ToLower())
            {
                case "firefox":
                    options = new FirefoxOptions();
                    break;
                case "edge":
                    options = new EdgeOptions();
                    break;
                case "safari":
                    options = new SafariOptions();
                    break;
                case "chrome":
                default:
                    options = new ChromeOptions();
                    break;
            }

            options.BrowserVersion = "latest";

            Dictionary<string, object> ltOptions = new Dictionary<string, object>
            {
                ["username"] = LT_USERNAME,
                ["accessKey"] = LT_ACCESS_KEY,
                ["platformName"] = platform,
                ["build"] = build,
                ["project"] = project,
                ["w3c"] = true
            };

            options.AddAdditionalOption("LT:Options", ltOptions);

            return new RemoteWebDriver(new Uri($"https://{LT_USERNAME}:{LT_ACCESS_KEY}{gridURL}"), options.ToCapabilities());
        }
    }
}
