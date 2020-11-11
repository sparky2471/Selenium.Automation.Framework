using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Runtime.InteropServices;

namespace Selenium.Automation.Framework.Extensions
{
    public static class WebDriverExtensions
    {

        public static void ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static void TakeScreenshot(this IWebDriver driver, string filepath, string fileName)
        {
            // Try to create the directory if it does not exist.
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            // Attempt to save a screenshot and log an error if it fails.
            try
            {

                var slashes = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\\" : "//";
                // Build file name.
                filepath += slashes + fileName;

                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filepath);
                System.Console.WriteLine("Successfully saved screenshot: " + filepath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Failed to save screenshot: " + ex.Message, ex.InnerException);
            }
        }
    }
}