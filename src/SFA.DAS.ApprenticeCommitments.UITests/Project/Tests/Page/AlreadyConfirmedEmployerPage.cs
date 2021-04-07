using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedEmployerPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "You have confirmed your employer";

        public AlreadyConfirmedEmployerPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyText(NotificationBar, PageTitle);
            VerifyPage(PageHeader, context.Get<ObjectContext>().GetEmployerName().Replace("  "," "));
        }
    }
}
