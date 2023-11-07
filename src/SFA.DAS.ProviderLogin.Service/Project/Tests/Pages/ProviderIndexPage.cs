using OpenQA.Selenium;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class ProviderIndexPage : IdamsLoginBasePage
{
    protected override string PageTitle => "Apprenticeship service for training providers: sign in or register for an account";

    internal static By ProviderIndexStartSelector => By.CssSelector("a[href='/signin'].govuk-button.govuk-button--start");

    public ProviderIndexPage(ScenarioContext context) : base(context) { }

    public void StartNow() => formCompletionHelper.ClickElement(ProviderIndexStartSelector);
}
