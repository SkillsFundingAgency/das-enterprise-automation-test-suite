using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.StubPages
{
    public class StubYouHaveSignedInApplyPage(ScenarioContext context, string username, string idOrUserRef, bool newUser) : StubYouHaveSignedInBasePage(context, username, idOrUserRef, newUser)
    {

        protected override By MainContent => By.CssSelector("[id='estimate-start-transfer']");

        protected override By ContinueButton => By.CssSelector(".govuk-body a.govuk-button");

        public new void Continue() => base.Continue();
    }
}
