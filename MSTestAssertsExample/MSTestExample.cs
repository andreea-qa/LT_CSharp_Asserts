using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SetUp;

namespace MSTestAsserts
{
    [TestClass]
    public class MSTestExample
    {
        private static IWebDriver driver;        

        [TestInitialize]
        public void OpenApplication()
        {
            driver = LambdaDriverFactory.CreateDriver(project: "MSTest Asserts");
            driver.Navigate().GoToUrl("https://ecommerce-playground.lambdatest.io/");
        }

        [TestMethod]
        public void ValidateCorrectCategoryIsSelected()
        {
            try
            {
                // Navigate to the Components page
                driver.FindElement(By.XPath("//a[contains(normalize-space(.), 'Shop by Category')]")).Click();
                driver.FindElement(By.XPath("//a[.//span[normalize-space(text())='Software']]")).Click();

                // Wait for the filter menu to be displayed
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementExists(By.Id("mz-filter-0")));

                // Validate the title of the page is correct
                Assert.IsTrue(driver.Title.Equals("Software"), "The page was not loaded.");

                // Other ways to validate
                Assert.AreEqual("Software", driver.Title, "The page was not loaded.");
                Assert.IsFalse(driver.Title == "0", "The page was not loaded.");

                // Show test as passed in LambdaTest
                ((IJavaScriptExecutor)driver).ExecuteScript("lambda-status=passed");
            }
            catch 
            {
                // Show test as failed in LambdaTest
                ((IJavaScriptExecutor)driver).ExecuteScript("lambda-status=failed");
            }
            
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}