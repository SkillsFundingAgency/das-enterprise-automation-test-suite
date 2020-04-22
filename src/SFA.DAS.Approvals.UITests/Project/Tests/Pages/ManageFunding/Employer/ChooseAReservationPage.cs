using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ChooseAReservationPage : BasePage
    {
        protected override string PageTitle => "Choose a Reservation";
        private By CreateANewReservationRadioButton => By.CssSelector(".govuk-label--s");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ChooseAReservationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ChooseAReservationPage ChooseCreateANewReservationRadioButton()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(CreateANewReservationRadioButton, "CreateNew");
            return new ChooseAReservationPage(_context);
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickSaveAndContinueButton()
        {
            Continue();
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }
        public AddApprenticeDetailsPage DynamicHomePageClickSaveAndContinueToAddAnApprentices()
        {
            _formCompletionHelper.SelectRadioOptionByText(RadioLabels,"Food Technologist - Level 3 starting between Apr 2020 to Jun 2020");
            Continue();
            return new AddApprenticeDetailsPage(_context);
        }
    }
}