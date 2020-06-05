using SFA.DAS.ConfigurationBuilder;
namespace SFA.DAS.UI.Framework.TestSupport
{
    public static class ObjectContextBrowserExtension
    {
        private const string FireFoxDriverLocation = "firefoxdriverlocation";
        private const string ChromeDriverLocation = "chromedriverlocation";
        private const string IeDriverLocation = "iedriverlocation";

        public static void SetFireFoxDriverLocation(this ObjectContext objectContext, string value)
        {
            objectContext.Set(FireFoxDriverLocation, value);
        }

        public static string GetFireFoxDriverLocation(this ObjectContext objectContext)
        {
            return objectContext.Get(FireFoxDriverLocation);
        }

        public static void SetChromeDriverLocation(this ObjectContext objectContext, string value)
        {
            objectContext.Set(ChromeDriverLocation, value);
        }

        public static string GetChromeDriverLocation(this ObjectContext objectContext)
        {
            return objectContext.Get(ChromeDriverLocation);
        }

        public static void SetIeDriverLocation(this ObjectContext objectContext, string value)
        {
            objectContext.Set(IeDriverLocation, value);
        }

        public static string GetIeDriverLocation(this ObjectContext objectContext)
        {
            return objectContext.Get(IeDriverLocation);
        }
    }
}
