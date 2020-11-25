using System;

namespace Selenium.Automation.Framework.Base.Helpers
{
    public static class DateHelper
    {
        public static string GenerateDateStamp(string formatting)
        {
            return DateTime.Now.ToString(formatting);
        }

        public static string GenerateDate()
        {
            return GenerateDateStamp("yyyy-MM-dd");
        }
    }
}
