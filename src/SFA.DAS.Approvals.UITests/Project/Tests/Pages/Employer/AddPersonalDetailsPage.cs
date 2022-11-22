using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddPersonalDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Add personal details";

        public AddPersonalDetailsPage(ScenarioContext context) : base(context) { }

        public AddTrainingDetailsPage SubmitValidPersonalDetails()
        {
            EnterApprenticeMandatoryValidDetails();

            EnterDob();

            formCompletionHelper.ClickElement(SaveAndContinueButton);

            return new AddTrainingDetailsPage(context);
        }

        public AddTrainingDetailsPage DraftDynamicHomePageAddValidPersonalDetails()
        {
            EnterApprenticeMandatoryValidDetails();

            formCompletionHelper.ClickElement(SaveAndContinueButton);

            return new AddTrainingDetailsPage(context);
        }

        public AddTrainingDetailsPage ContinueToAddTrainingDetailsPage()
        {
            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new AddTrainingDetailsPage(context);
        }
    }
}