using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedRolesAndResponsibilitiesPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => SectionHelper.Section5;
        private string GreenTickTextInfo => "You have read through roles and responsibilities";

        public AlreadyConfirmedRolesAndResponsibilitiesPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
            pageInteractionHelper.VerifyText(GreenTickText, GreenTickTextInfo);
        }

        public new AlreadyConfirmedRolesAndResponsibilitiesPage VerifyRolesYourResponsibilitiesTab()
        {
            base.VerifyRolesYourResponsibilitiesTab();
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
