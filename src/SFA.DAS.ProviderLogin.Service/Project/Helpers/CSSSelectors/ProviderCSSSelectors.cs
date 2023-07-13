using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers.CSSSelectors
{
    public static class ProviderCSSSelectors
    {
        internal static By ProviderIndexStartSelector => EnvironmentConfig.IsTestEnvironment ? By.CssSelector("a.govuk-button.govuk-button--start[aria-label='Start now']") : By.CssSelector(".button-start");
    }
}
