using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class DoYouGiveTrainingProviderPermissionToRecruitApprenticesPage : BasePage
    {
        protected override string PageTitle => "Do you give";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion
                
        public DoYouGiveTrainingProviderPermissionToRecruitApprenticesPage (ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        public ConfirmTrainingProviderPermissionsPage ClickYesToAddRecruitApprentice()
        {
            _formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            _formCompletionHelper.Click(ContinueButton);
            return new ConfirmTrainingProviderPermissionsPage(_context);
        }
        public ConfirmTrainingProviderPermissionsPage ClickNoToAddRecruitApprentice()
        {
            _formCompletionHelper.SelectRadioOptionByText(RadioLabels, "No");
            _formCompletionHelper.Click(ContinueButton);
            return new ConfirmTrainingProviderPermissionsPage(_context);
        }

    }
}