using System;
namespace Selenium.Automation.Framework.Settings
{

    // Used by the framework to determine which browser/web driver to load when the test starts.

    public enum BrowserType
    {
        // Start Chrome Driver
        Chrome,
        // Start IE Driver
        InternetExplorer,
        // Start Firefox Driver
        Firefox,
    }
}