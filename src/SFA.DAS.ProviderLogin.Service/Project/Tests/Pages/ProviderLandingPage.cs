using OpenQA.Selenium;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class ProviderLandingPage(ScenarioContext context) : IdamsLoginBasePage(context, false)
{
    protected override string PageTitle => ProviderLandingPageTitle;

    protected override By PageHeader => ProviderLandingPageIdentifier;

    public static string ProviderLandingPageTitle => "Apprenticeship service for training providers: sign in or register for an account";

    public static By ProviderLandingPageIdentifier => By.CssSelector(".govuk-heading-xl");

    private static By StartNowSelector => By.CssSelector("a[href='/signin'].govuk-button.govuk-button--start");

    public void ClickStartNow() => formCompletionHelper.ClickElement(StartNowSelector);
}
