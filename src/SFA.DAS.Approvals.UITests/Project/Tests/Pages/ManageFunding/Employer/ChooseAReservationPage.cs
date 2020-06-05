using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ChooseAReservationPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Choose a Reservation";
        private By CreateANewReservationRadioButton => By.CssSelector(".govuk-label--s");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        private By ChooseCourseReservation => By.XPath("(//div[@class='govuk-radios']//div[@class='govuk-radios__item'])[1]");
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ChooseAReservationPage(ScenarioContext context) : base(context) => _context = context;

        public ChooseAReservationPage ChooseCreateANewReservationRadioButton()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(CreateANewReservationRadioButton, "CreateNew");
            return new ChooseAReservationPage(_context);
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickSaveAndContinueButton()
        {
            Continue();
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }
        public AddApprenticeDetailsPage DynamicHomePageClickSaveAndContinueToAddAnApprentices()
        {
            formCompletionHelper.Click(ChooseCourseReservation);
            Continue();
            return new AddApprenticeDetailsPage(_context);
        }
    }
}