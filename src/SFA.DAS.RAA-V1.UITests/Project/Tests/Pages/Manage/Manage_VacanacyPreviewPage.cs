using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_VacanacyPreviewPage : Manage_HeaderSectionBasePage
    {
        protected override string PageTitle => "Vacancy preview";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly TableRowHelper _tableRowHelper;
        private readonly RAADataHelper _dataHelper;
        #endregion

        private By Refer => By.CssSelector("#btnReject");
        

        public Manage_VacanacyPreviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tableRowHelper = context.Get<TableRowHelper>();
            _dataHelper = context.Get<RAADataHelper>();
            VerifyPage();
        }

        public void ReferVacancy()
        {
            _formCompletionHelper.Click(Refer);
            SignOut();
        }
    }

    public class Manage_OpportunityPreviewPage : Manage_VacanacyPreviewPage
    {
        protected override string PageTitle => "Opportunity preview";

        public Manage_OpportunityPreviewPage(ScenarioContext context) : base(context)
        {

        }
    }

}
