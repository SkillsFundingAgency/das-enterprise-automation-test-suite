using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class DynamicHomePages : HomePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private string VerifyStatusMessage = "DRAFT";
        private By VerifyStatus = By.Id("draft");
        private By DynamicHomeContinueButton = By.XPath("(//a[@class='button'])[1]");
        public DynamicHomePages(ScenarioContext context) : base(context) 
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }
        public ReserveFundingToTrainAndAssessAnApprenticePage StartNowToReserveFunding()
        {
            _formCompletionHelper.ClickElement(StartNowButton);
            return new ReserveFundingToTrainAndAssessAnApprenticePage(_context);
        }
        public EditApprenticePage CheckStatusAndAddDetails()
        {
            _pageInteractionHelper.VerifyText(VerifyStatus, VerifyStatusMessage);
            _formCompletionHelper.Click(DynamicHomeContinueButton);
            return new EditApprenticePage(_context);
        }
    }
}