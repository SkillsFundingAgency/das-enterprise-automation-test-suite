using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmApprenticeDeliveryModelPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Select the apprenticeship delivery model";

        public ProviderConfirmApprenticeDeliveryModelPage(ScenarioContext context) : base(context) { }

        public ProviderEditApprenticeTrainingDetailsPage ConfirmDeliveryModelChangeToRegular()
        {
            Continue();
            return new ProviderEditApprenticeTrainingDetailsPage(context);
        }
    }
}