using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ChooseAReservationPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Select a Reservation";

        protected override bool TakeFullScreenShot => false;

        private static By CreateANewReservationRadioButton => By.CssSelector(".govuk-label--s");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        private static By ChooseCourseReservation => By.XPath("(//div[@class='govuk-radios']//div[@class='govuk-radios__item'])[1]");

        public ChooseAReservationPage ChooseCreateANewReservationRadioButton()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(CreateANewReservationRadioButton, "CreateNew");
            return new ChooseAReservationPage(context);
        }

        public EmployerSelectStandardPage ClickSaveAndContinueButton()
        {
            Continue();
            return new EmployerSelectStandardPage(context);
        }

        public AddTrainingProviderDetailsPage SelectAReservation()
        {
            formCompletionHelper.Click(ChooseCourseReservation);
            Continue();
            return new AddTrainingProviderDetailsPage(context);
        }

        public AddTrainingProviderDetailsPage ChooseReservationFromContext()
        {
            var reservationId = objectContext.GetReservationId();
            var chooseReservationById = By.Id($"SelectedReservationId-{reservationId}");

            formCompletionHelper.SelectRadioOptionByLocator(chooseReservationById);
            Continue();
            return new AddTrainingProviderDetailsPage(context);
        }

        public AddApprenticeDetailsPage ChooseSecondReservationFromContext()
        {
            var reservationId = objectContext.GetSecondReservationId();
            var chooseReservationById = By.Id($"SelectedReservationId-{reservationId}");

            formCompletionHelper.SelectRadioOptionByLocator(chooseReservationById);
            Continue();
            return new AddApprenticeDetailsPage(context);
        }

    }
}