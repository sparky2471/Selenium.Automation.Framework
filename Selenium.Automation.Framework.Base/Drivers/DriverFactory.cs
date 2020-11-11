/*======================================================================================================
 *  Constructor class to create new instances of WebDrivers.
 *======================================================================================================*/
using Selenium.Automation.Framework.Configuration;
using Selenium.Automation.Framework.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace Selenium.Automation.Framework.Drivers
{
    
    // Default Implementation of IDriverFactory
    
    public class DriverFactory : IDriverFactory
    {
        
        // Application path
        
        public readonly string applicationPath;

        
        // Driver constructor path
        
        public DriverFactory()
        {
            applicationPath = AppDomain.CurrentDomain.BaseDirectory;
        }

        
        // Loads a webdriver based off provided configuration settings.
       
        public virtual IWebDriver LoadBrowser(int commandTimeout = 45)
        {
            bool useHeadlessMode = Settings.SeleniumSettings.UseHeadlessMode;
            BrowserType browserType = Settings.SeleniumSettings.Browser;
            var timeout = TimeSpan.FromSeconds(commandTimeout);
            IWebDriver driver = browserType switch
            {
                BrowserType.Chrome => InstantiateChromeDriver(useHeadlessMode, timeout),
                BrowserType.Firefox => InstantiateFirefoxDriver(useHeadlessMode, timeout),
                BrowserType.InternetExplorer => InstantiateInternetExplorerDriver(useHeadlessMode, timeout),
                _ => InstantiateChromeDriver(useHeadlessMode, timeout),
            };

            // Set timeout defaults based on configuration settings.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.SeleniumSettings.ImplicitWaitTimeout);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Settings.SeleniumSettings.PageLoadTimeout);

            return driver;
        }


        // Start a new ChromeDriver instance.

        protected ChromeDriver InstantiateChromeDriver(bool useHeadlessMode, TimeSpan commandTimeout)
        {
            var options = LoadChromeOptions(useHeadlessMode);
            return new ChromeDriver(applicationPath + Settings.SeleniumSettings.WebDriverPath, options, commandTimeout);
        }

        
        // Creates an options object to configure a ChromeDriver instance.
        
        protected virtual ChromeOptions LoadChromeOptions(bool useHeadlessMode)
        {
            var chromeOptions = new ChromeOptions();

            // If useHeadlessMode true, run browser headless meaning the browswer won't open to run the test. 

            if (useHeadlessMode)
            {
                chromeOptions.AddArgument("--headless");
            }

            /* ChromeDriver options that need to be passed or most of the tests will break.
             * It's worth noting that the ChromeDriver breaks all the time so don't update the driver too often. 
             */

            chromeOptions.AddArgument("incognito");
            chromeOptions.AddArgument("--disable-popup-blocking");
            chromeOptions.AddArgument("--start-maximized"); // https://stackoverflow.com/a/26283818/1689770
            chromeOptions.AddArgument("--enable-automation"); // https://stackoverflow.com/a/43840128/1689770
            chromeOptions.AddArgument("--no-sandbox"); //https://stackoverflow.com/a/50725918/1689770
            chromeOptions.AddArgument("--disable-infobars"); //https://stackoverflow.com/a/43840128/1689770
            chromeOptions.AddArgument("--disable-dev-shm-usage"); //https://stackoverflow.com/a/50725918/1689770
            chromeOptions.AddArgument("--disable-browser-side-navigation"); //https://stackoverflow.com/a/49123152/1689770
            chromeOptions.AddArgument("--disable-gpu"); //https://stackoverflow.com/questions/51959986/how-to-solve-selenium-chromedriver-timed-out-receiving-message-from-renderer-exc
            chromeOptions.AddAdditionalCapability("useAutomationExtension", false);

            return chromeOptions;
        }

        
        // Start a new IEDriver instance.
        
        protected InternetExplorerDriver InstantiateInternetExplorerDriver(bool useHeadlessMode, TimeSpan commandTimeout)
        {
            InternetExplorerOptions options = LoadInternetExplorerOptions(useHeadlessMode);
            return new InternetExplorerDriver(applicationPath + Settings.SeleniumSettings.WebDriverPath, options, commandTimeout);
        }

        
        // Creates a configuration object for InternetExplorer.
        
        protected virtual InternetExplorerOptions LoadInternetExplorerOptions(bool headlessMode)
        {
            return new InternetExplorerOptions();
        }


        // Start a new FirefoxDriver instance.

        protected FirefoxDriver InstantiateFirefoxDriver(bool useHeadlessMode, TimeSpan commandTimeout)
        {
            var options = LoadFirefoxOptions(useHeadlessMode);
            return new FirefoxDriver(applicationPath + Settings.SeleniumSettings.WebDriverPath, options, commandTimeout);
        }

        
        // Creates configuration object for Firefox browser.
        
        protected virtual FirefoxOptions LoadFirefoxOptions(bool useHeadlessMode)
        {
            return new FirefoxOptions();
        }
    }
}
