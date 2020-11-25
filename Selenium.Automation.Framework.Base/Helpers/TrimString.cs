using System;

namespace Selenium.Automation.Framework.Base.Helpers
{
    public static class TrimString
    {
        public static string ShortenString(string str)
        {
            str = str.Trim();
            return str;
        }
    }
}
