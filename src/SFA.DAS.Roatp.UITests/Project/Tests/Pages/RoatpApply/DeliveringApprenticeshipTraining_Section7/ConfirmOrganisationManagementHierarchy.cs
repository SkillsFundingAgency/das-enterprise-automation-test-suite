using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class ConfirmOrganisationManagementHierarchy : RoatpApplyBasePage
    {
        protected override string PageTitle => "Confirm your organisation's management hierarchy for apprenticeships";

        public ConfirmOrganisationManagementHierarchy(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage ContinueToApplicationOverview()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}