using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ChooseAReservationPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Choose a Reservation";

        protected override bool TakeFullScreenShot => false;

        private static By CreateANewReservationRadioButton => By.CssSelector(".govuk-label--s");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        private static By ChooseCourseReservation => By.XPath("(//div[@class='govuk-radios']//div[@class='govuk-radios__item'])[1]");

        public ChooseAReservationPage(ScenarioContext context) : base(context) { }

        public ChooseAReservationPage ChooseCreateANewReservationRadioButton()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(CreateANewReservationRadioButton, "CreateNew");
            return new ChooseAReservationPage(context);
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickSaveAndContinueButton()
        {
            Continue();
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(context);
        }

        public SelectStandardPage DynamicHomePageClickSaveAndContinueToAddAnApprentices()
        {
            formCompletionHelper.Click(ChooseCourseReservation);
            Continue();
            return new SelectStandardPage(context);
        }
    }
}