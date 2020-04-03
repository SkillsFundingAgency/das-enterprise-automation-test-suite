using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class TrainingProviderAddedPage : BasePage
    {
        protected override string PageTitle => "Training provider added";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public TrainingProviderAddedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        public DoYouGiveTrainingProviderPermissionToAddApprenticeRecordsPage SelectContinueInEmployerTrainingProviderAddedPage()
        {
            _formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Set permissions for this training provider");
            Continue();
            return new DoYouGiveTrainingProviderPermissionToAddApprenticeRecordsPage (_context);
        }
    }
}