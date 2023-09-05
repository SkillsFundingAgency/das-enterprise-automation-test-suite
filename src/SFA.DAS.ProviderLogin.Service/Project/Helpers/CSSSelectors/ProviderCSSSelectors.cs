using OpenQA.Selenium;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers.CSSSelectors;

public static class ProviderCSSSelectors
{
    //pas login changes
    internal static By ProviderIndexStartSelector => By.CssSelector("a.govuk-button.govuk-button--start[aria-label='Start now']");

    //internal static By ProviderIndexStartSelector => By.CssSelector(".button-start");
}
