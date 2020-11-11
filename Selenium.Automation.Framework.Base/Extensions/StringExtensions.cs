using System;

namespace Selenium.Automation.Framework.Extensions
{
    public static class StringExtensions
    {
        public static T Convert<T>(this string value)
        {
            /* Cast string to enum value.
            *
            If it fails, throw an exception and tell user the valid values.*/
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch (ArgumentException)
            {
                string message = "Failed to convert [" + value + "] to type of " + typeof(T) + ".";
                message += "Possible values are: ";

                foreach (object enumVal in Enum.GetValues(typeof(T)))
                {
                    message += enumVal.ToString() + " ";
                }

                throw new ArgumentException(message);
            }
        }
    }
}
