using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public abstract class RoatpAdminBasePage : RoatpBasePage
    {
        #region Helpers and Context
        protected readonly RoatpAdminDataHelpers admindataHelpers;
        #endregion

        protected By RadioInputs => By.CssSelector(".govuk-radios__input");

        public RoatpAdminBasePage(ScenarioContext context) : base(context)
        {
            admindataHelpers = context.Get<RoatpAdminDataHelpers>();
            VerifyPage();
        }

        protected void Back() => formCompletionHelper.ClickLinkByText("Back");
    }
}
