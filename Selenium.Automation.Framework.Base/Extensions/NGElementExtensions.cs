using OpenQA.Selenium;
using Protractor;
using System.Collections.ObjectModel;

namespace Selenium.Automation.Framework.Extensions
{
    public static class NGElementExtensions
    {
        public static void TrySelectOption(this NgWebElement selectionPanel, int index)
        {
            ReadOnlyCollection<NgWebElement> options = selectionPanel.FindElements(By.TagName("mat-option"));
            options[index].Click();
        }
    }
}
