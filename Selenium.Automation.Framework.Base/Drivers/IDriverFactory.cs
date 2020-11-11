using OpenQA.Selenium;

namespace Selenium.Automation.Framework.Drivers
{

    // Interface for the Driverfactory class.

    public interface IDriverFactory
    {

        // Start a new browser based off the configuration setting.

        IWebDriver LoadBrowser(int commandTimeout);
    }
}