using OpenQA.Selenium;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers.CSSSelectors;

public static class ProviderCSSSelectors
{
    internal static By ProviderIndexStartSelector => By.CssSelector("a.govuk-button.govuk-button--start[aria-label='Start now']");
}
