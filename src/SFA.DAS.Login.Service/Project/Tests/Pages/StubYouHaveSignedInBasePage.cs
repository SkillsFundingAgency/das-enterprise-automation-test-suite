using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service.Project.Tests.Pages;

public abstract class StubYouHaveSignedInBasePage : VerifyBasePage
{
    protected override string PageTitle => "You've signed in";

    protected override bool CanAnalyzePage => false;

    protected virtual By MainContent => By.CssSelector("[id='main-content']");

    protected override By ContinueButton => By.CssSelector("a.govuk-button");

    public StubYouHaveSignedInBasePage(ScenarioContext context, string username, string idOrUserRef, bool newUser) : base(context)
    {
        MultipleVerifyPage(
        [
            () => VerifyPage(),
            () => VerifyPage(MainContent, username),
            () => newUser || VerifyPage(MainContent, idOrUserRef)
        ]);
    }
}
