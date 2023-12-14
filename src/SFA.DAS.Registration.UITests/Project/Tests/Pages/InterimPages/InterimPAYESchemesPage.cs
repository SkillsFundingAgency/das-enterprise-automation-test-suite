using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimPAYESchemesPage(ScenarioContext context, bool navigate) : InterimEmployerBasePage(context, navigate)
    {
        protected override string PageTitle => "PAYE schemes";

        protected override string Linktext => "PAYE schemes";
    }
}
