using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Selenium.Automation.Framework.Extensions
{
    public static class WebElementExtensions
    {
        public static string Value(this IWebElement element) => element.GetAttribute("value");


        // Can't get this to work
        public static void EnterText(this IWebElement element, string text, bool clearText = false)
        {
            if (clearText)
            {
                element.Clear();
            }

            element.SendKeys(text);
        }

        public static List<string> GetOptions(this SelectElement element)
        {
            List<string> optionsAsString = new List<string>();
            string optionText;

            foreach (IWebElement e in element.Options.ToList())
            {
                optionText = e.Text;
                optionText = optionText.TrimStart();
                optionText = optionText.TrimEnd();
                optionsAsString.Add(optionText);
            }

            return optionsAsString;
        }

    }
}
