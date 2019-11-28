using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public abstract class Manage_HeaderSectionBasePage : BasePage
    {

        #region Helpers and Context
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly RAADataHelper raadataHelper;
        #endregion

        private By AgencyHomeCss => By.Id("proposition-name");
        private By SignOutCss => By.Id("signout-link");

        public Manage_HeaderSectionBasePage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            raadataHelper = context.Get<RAADataHelper>();
            VerifyPage();
        }

        protected void SignOut()
        {
            AgentHome();
            formCompletionHelper.Click(SignOutCss);
        }

        protected void AgentHome()
        {
            formCompletionHelper.Click(AgencyHomeCss);
        }
    }
}
