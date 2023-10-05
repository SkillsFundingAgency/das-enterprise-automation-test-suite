using OpenQA.Selenium;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers.CSSSelectors;

public static class ProviderCSSSelectors
{
    internal static By ProviderIndexStartSelector => By.CssSelector("a[href='/signin'].govuk-button.govuk-button--start");
}
