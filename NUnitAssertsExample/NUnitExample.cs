using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SetUp;

namespace NUnitAsserts
{
    internal class NUnitExampe
    {
        private static IWebDriver driver;
        
        [SetUp]
        public void OpenApplication()
        {

            driver = LambdaDriverFactory.CreateDriver(project: "NUnit Asserts");
            driver.Navigate().GoToUrl("https://ecommerce-playground.lambdatest.io/");
        }

        [Test]
        public void ValidateProductIsAddedToTheCart()
        {
            try
            {
                // Navigate to the Components page
                driver.FindElement(By.XPath("//a[contains(normalize-space(.), 'Shop by Category')]")).Click();
                driver.FindElement(By.XPath("//a[.//span[normalize-space(text())='Components']]")).Click();

                // Hover the first HTC Touch product HD in the carousel
                Actions builder = new Actions(driver);
                builder.MoveToElement(driver.FindElement(By.XPath("//div[@class='carousel-item active']/img[@title='HTC Touch HD']")))
                       .Build().Perform();

                // Wait for the product menu to be visible
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement ComposeButton = wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[span[text()='Add to Cart']]")));

                // Click Add to Cart button
                driver.FindElement(By.XPath("//button[span[text()='Add to Cart']]")).Click();

                // Wait for the notification message to be visible
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'toast') and @role='alert']")));

                // Validate that the cart contains one item
                string expectedText = driver.FindElement(By.XPath("//div[@class='cart-icon']/span")).Text;
                Assert.That(expectedText.Equals("1"), "The cart was not updated.");

                // Other ways to validate
                Assert.IsTrue(expectedText.Equals("1"), "The cart was not updated.");
                Assert.AreEqual(expectedText, "1", "The cart was not updated.");
                Assert.IsFalse(expectedText.Equals("0"), "The cart was not updated.");
                Assert.AreNotEqual(expectedText, "0", "The cart was not updated.");
                Assert.IsNotNull(expectedText, "The cart was not updated.");

                // Show test as passed in LambdaTest
                ((IJavaScriptExecutor)driver).ExecuteScript("lambda-status=passed");
            }
            catch
            {
                // Show test as failed in LambdaTest
                ((IJavaScriptExecutor)driver).ExecuteScript("lambda-status=failed");
            }
            
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Dispose();
        }
    }
}
