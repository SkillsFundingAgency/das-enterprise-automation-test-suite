using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedEmployerPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "You have confirmed this is your employer";

        public AlreadyConfirmedEmployerPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyText(NotificationBar, PageTitle);
            VerifyPage(PageHeader, objectContext.GetEmployerName().Replace("  "," "));
        }
    }
}
