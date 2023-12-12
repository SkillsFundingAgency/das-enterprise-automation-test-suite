using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.StubPages
{
    public class StubYouHaveSignedInApplyPage : StubYouHaveSignedInBasePage
    {

        protected override By MainContent => By.CssSelector("[id='estimate-start-transfer']");

        protected override By ContinueButton => By.CssSelector(".govuk-body a.govuk-button");

        public StubYouHaveSignedInApplyPage(ScenarioContext context, string username, string idOrUserRef, bool newUser) : base(context, username, idOrUserRef, newUser)
        {
            
        }

        public new void Continue() => base.Continue();
    }
}
