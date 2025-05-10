using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SetUp
{
    public static class LambdaDriverFactory
    {
        private static readonly string gridURL = "@hub.lambdatest.com/wd/hub";
        private static readonly string LT_USERNAME = Environment.GetEnvironmentVariable("LT_USERNAME");
        private static readonly string LT_ACCESS_KEY = Environment.GetEnvironmentVariable("LT_ACCESS_KEY");

        public static IWebDriver CreateDriver(string platform = "Windows 10", string build = "Selenium CSharp", string project = "Default Project")
        {
            ChromeOptions capabilities = new ChromeOptions();
            capabilities.BrowserVersion = "latest";

            Dictionary<string, object> ltOptions = new Dictionary<string, object>
            {
                ["username"] = LT_USERNAME,
                ["accessKey"] = LT_ACCESS_KEY,
                ["platformName"] = platform,
                ["build"] = build,
                ["project"] = project,
                ["w3c"] = true,
                ["plugin"] = "c#-mstest"
            };

            capabilities.AddAdditionalOption("LT:Options", ltOptions);

            return new RemoteWebDriver(new Uri($"https://{LT_USERNAME}:{LT_ACCESS_KEY}{gridURL}"), capabilities);
        }
    }
}
