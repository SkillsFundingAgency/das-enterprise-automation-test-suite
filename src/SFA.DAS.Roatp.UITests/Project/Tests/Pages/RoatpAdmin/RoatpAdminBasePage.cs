using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public abstract class RoatpAdminBasePage : RoatpBasePage
    {
        protected By RadioInputs => By.CssSelector(".govuk-radios__input");

        public RoatpAdminBasePage(ScenarioContext context) : base(context) => VerifyPage();

        protected void Back() => formCompletionHelper.ClickLinkByText("Back");
    }
}
