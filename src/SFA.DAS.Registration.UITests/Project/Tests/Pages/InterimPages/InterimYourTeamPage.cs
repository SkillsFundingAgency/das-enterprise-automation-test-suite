using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public abstract class InterimYourTeamPage(ScenarioContext context, bool navigate) : InterimEmployerBasePage(context, navigate)
    {
        protected override string PageTitle => "Your team";

        protected override string Linktext => "Your team";
    }
}
