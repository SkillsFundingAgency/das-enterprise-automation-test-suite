using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimYourTeamPage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Your team";

        protected override string Linktext => "Your team";

        public InterimYourTeamPage(ScenarioContext context, bool navigate) : base(context, navigate) { }
    }
}
