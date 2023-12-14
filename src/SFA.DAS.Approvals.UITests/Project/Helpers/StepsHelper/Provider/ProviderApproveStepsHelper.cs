using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ProviderApproveStepsHelper(ScenarioContext context)
    {
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);

        private readonly ProviderEditStepsHelper _providerEditStepsHelper = new ProviderEditStepsHelper(context);

        public void Approve() => SubmitApprove(_providerCommonStepsHelper.CurrentCohortDetails());

        public void EditAndApprove() => SubmitApprove(EditApprentice());

        public void ValidateFlexiJobContentAndApproveCohort() => EditApprentice().ValidateFlexiJobTagAndSubmitApprove();

        private ProviderApproveApprenticeDetailsPage EditApprentice() => _providerEditStepsHelper.EditApprentice();

        public void ValidatePortableFlexiJobContentAndApproveCohort()
        {
            var providerHomePage = _providerCommonStepsHelper.GoToProviderHomePage(context.GetPortableFlexiJobProviderConfig<PortableFlexiJobProviderConfig>(), true);

            var cohortPage = _providerCommonStepsHelper.CurrentCohortDetails(providerHomePage);

            _providerEditStepsHelper.EditApprentice(cohortPage, false).ValidatePortableFlexiJobTagAndSubmitApprove();
        }

        private static void SubmitApprove(ProviderApproveApprenticeDetailsPage page) => page.SubmitApprove();

    }
}