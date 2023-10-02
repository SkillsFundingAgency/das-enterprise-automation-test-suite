using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ProviderApproveStepsHelper
    {
        private readonly ScenarioContext _context;

        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;

        private readonly ProviderEditStepsHelper _providerEditStepsHelper;

        public ProviderApproveStepsHelper(ScenarioContext context)
        {
            _context = context;

            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);

            _providerEditStepsHelper = new ProviderEditStepsHelper(context);
        }

        public void Approve() => SubmitApprove(_providerCommonStepsHelper.CurrentCohortDetails());

        public void EditAndApprove() => SubmitApprove(EditApprentice());

        public void ValidateFlexiJobContentAndApproveCohort() => EditApprentice().ValidateFlexiJobTagAndSubmitApprove();

        private ProviderApproveApprenticeDetailsPage EditApprentice() => _providerEditStepsHelper.EditApprentice();

        public void ValidatePortableFlexiJobContentAndApproveCohort()
        {
            var providerHomePage = _providerCommonStepsHelper.GoToProviderHomePage(_context.GetPortableFlexiJobProviderConfig<PortableFlexiJobProviderConfig>(), true);

            var cohortPage = _providerCommonStepsHelper.CurrentCohortDetails(providerHomePage);

            _providerEditStepsHelper.EditApprentice(cohortPage, false).ValidatePortableFlexiJobTagAndSubmitApprove();
        }

        private void SubmitApprove(ProviderApproveApprenticeDetailsPage page) => page.SubmitApprove();

    }
}