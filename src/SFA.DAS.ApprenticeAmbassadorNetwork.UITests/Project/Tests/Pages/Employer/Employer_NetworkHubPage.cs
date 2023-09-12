using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class Employer_NetworkHubPage : AanBasePage
    {
        protected override string PageTitle => "Your network hub";

        public Employer_NetworkHubPage(ScenarioContext context) : base(context) => VerifyPage();

        public EventsHubPage AccessEventsHub()
        {
            formCompletionHelper.ClickLinkByText("Events hub");
            return new EventsHubPage(context);
        }

    }
}