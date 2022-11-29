using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddPersonalDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        private static By SaveAndContinueButton => By.CssSelector("#main-content .govuk-button");

        protected override string PageTitle => "Add personal details";

        public AddPersonalDetailsPage(ScenarioContext context) : base(context) { }

        public AddTrainingDetailsPage SubmitValidPersonalDetails()
        {
            EnterApprenticeMandatoryValidDetails();

            EnterDob();

            SaveAndContinue();

            return new AddTrainingDetailsPage(context);
        }

        public AddTrainingDetailsPage DraftDynamicHomePageAddValidPersonalDetails()
        {
            EnterApprenticeMandatoryValidDetails();

            SaveAndContinue();

            return new AddTrainingDetailsPage(context);
        }

        public AddTrainingDetailsPage ContinueToAddTrainingDetailsPage()
        {
            SaveAndContinue();
            return new AddTrainingDetailsPage(context);
        }

        private void SaveAndContinue() => formCompletionHelper.ClickElement(SaveAndContinueButton);
    }
}