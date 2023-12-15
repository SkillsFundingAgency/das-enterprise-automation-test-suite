using OpenQA.Selenium;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class ProviderIndexPage(ScenarioContext context) : IdamsLoginBasePage(context)
{
    protected override string PageTitle => "Apprenticeship service for training providers: sign in or register for an account";

    internal static By ProviderIndexStartSelector => By.CssSelector("a[href='/signin'].govuk-button.govuk-button--start");

    public void StartNow() => formCompletionHelper.ClickElement(ProviderIndexStartSelector);
}
