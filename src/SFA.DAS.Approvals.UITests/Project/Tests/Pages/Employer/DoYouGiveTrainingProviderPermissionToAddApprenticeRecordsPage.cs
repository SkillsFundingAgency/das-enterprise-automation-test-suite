using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class DoYouGiveTrainingProviderPermissionToAddApprenticeRecordsPage : BasePage
    {
        protected override string PageTitle => "Do you give";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

       public DoYouGiveTrainingProviderPermissionToAddApprenticeRecordsPage(ScenarioContext context) : base(context)
       {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
       }
        public DoYouGiveTrainingProviderPermissionToRecruitApprenticesPage ClickYesToAddApprenticeRecords()
        {
            _formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            _formCompletionHelper.Click(ContinueButton);
            return new DoYouGiveTrainingProviderPermissionToRecruitApprenticesPage(_context);
        }

        public DoYouGiveTrainingProviderPermissionToRecruitApprenticesPage ClickNOToAddApprenticeRecords()
        {
            _formCompletionHelper.SelectRadioOptionByText(RadioLabels, "No");
            _formCompletionHelper.Click(ContinueButton);
            return new DoYouGiveTrainingProviderPermissionToRecruitApprenticesPage(_context);
        }
    }  
}