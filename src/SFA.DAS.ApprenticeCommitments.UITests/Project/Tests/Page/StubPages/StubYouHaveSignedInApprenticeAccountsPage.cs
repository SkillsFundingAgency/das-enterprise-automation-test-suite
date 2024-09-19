using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page.StubPages
{
    public class StubYouHaveSignedInApprenticeAccountsPage(ScenarioContext context, string username, string idOrUserRef, bool newUser) : StubYouHaveSignedInBasePage(context, username, idOrUserRef, newUser)
    {

        protected override By ContinueButton => By.CssSelector("a.govuk-button[href*='/apprenticeship']");

        public new void Continue() => base.Continue();
    }
}
