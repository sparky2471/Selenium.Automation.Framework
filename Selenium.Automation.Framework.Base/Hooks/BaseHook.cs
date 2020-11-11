/*======================================================================================================
 *  Base class to build each new instance of tests being run.
 *======================================================================================================*/
using System;
using Selenium.Automation.Framework.Configuration;
using BoDi;
using System.IO;
using TechTalk.SpecFlow;

namespace Selenium.Automation.Framework.Hooks
{
    [Binding]
    public class BaseHook
    {
        public IObjectContainer ObjectContainer { get; protected set; }

        public ScenarioContext ScenarioContext { get; protected set; }

        public BaseHook(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            ScenarioContext = scenarioContext;
            ObjectContainer = objectContainer;
        }

        public static void LoadConfiguration()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "configuration.json");
            Settings.LoadConfiguration(path);
        }

        public static void LoadConfiguration(string path)
        {
            Settings.LoadConfiguration(path);
        }
    }
}
