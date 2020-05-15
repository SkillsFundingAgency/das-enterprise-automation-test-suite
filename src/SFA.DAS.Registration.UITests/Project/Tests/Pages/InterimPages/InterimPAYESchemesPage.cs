using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimPAYESchemesPage : InterimEmployerBasePage
    {
        protected override string PageTitle => "PAYE schemes";
        protected override string Linktext => "PAYE schemes";

        public InterimPAYESchemesPage(ScenarioContext context, bool navigate) : base(context, navigate) { }
    }
}
