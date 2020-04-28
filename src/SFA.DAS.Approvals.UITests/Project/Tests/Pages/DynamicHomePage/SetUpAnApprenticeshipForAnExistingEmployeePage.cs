using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class SetUpAnApprenticeshipForAnExistingEmployeePage : BasePage
    {
        protected override string PageTitle => "Set up an apprenticeship for an existing employee";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion
        private By ClickReserveFunding = By.Id("reserve-funding");
        public SetUpAnApprenticeshipForAnExistingEmployeePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        public ReserveFundingToTrainAndAssessAnApprenticePage YesContinueToReserveFunding()
        {
            _formCompletionHelper.Click(ClickReserveFunding);
            return new ReserveFundingToTrainAndAssessAnApprenticePage(_context);
        }
    }
}
