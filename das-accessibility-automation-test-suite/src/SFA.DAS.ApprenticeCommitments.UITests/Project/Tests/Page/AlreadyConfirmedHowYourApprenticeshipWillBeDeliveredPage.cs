using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage : ConfirmYourDetailsBasePage
    {
        protected override string PageTitle => OverviewPageHelper.Section4;
        private static string GreenTickTextInfo => "You have read through how your apprenticeship will be delivered";

        public AlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
            pageInteractionHelper.VerifyText(GreenTickText, GreenTickTextInfo);
        }

        public FullyConfirmedOverviewPage NavigateBackToFullyConfirmedOverviewPage()
        {
            NavigateBack();
            return new FullyConfirmedOverviewPage(context);
        }
    }
}
