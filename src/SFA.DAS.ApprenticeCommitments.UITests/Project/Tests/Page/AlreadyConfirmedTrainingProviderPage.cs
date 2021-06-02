using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedTrainingProviderPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "You have confirmed your training provider";

        public AlreadyConfirmedTrainingProviderPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyText(NotificationBar, PageTitle);
            VerifyPage(PageHeader, objectContext.GetProviderName());
        }
    }
}
