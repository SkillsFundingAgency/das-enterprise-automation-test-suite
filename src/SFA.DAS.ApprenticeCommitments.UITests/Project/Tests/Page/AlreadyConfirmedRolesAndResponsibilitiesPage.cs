using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedRolesAndResponsibilitiesPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "You have confirmed your apprentice roles and responsibilities";

        public AlreadyConfirmedRolesAndResponsibilitiesPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyText(NotificationBar, PageTitle);
        }

        public new AlreadyConfirmedRolesAndResponsibilitiesPage VerifyRolesYouTab()
        {
            base.VerifyRolesYouTab();
            return this;
        }

        public new AlreadyConfirmedRolesAndResponsibilitiesPage VerifyRolesYourEmployerTab()
        {
            base.VerifyRolesYourEmployerTab();
            return this;
        }

        public new AlreadyConfirmedRolesAndResponsibilitiesPage VerifyRolesYourTrainingProviderTab()
        {
            base.VerifyRolesYourTrainingProviderTab();
            return this;
        }
    }
}
