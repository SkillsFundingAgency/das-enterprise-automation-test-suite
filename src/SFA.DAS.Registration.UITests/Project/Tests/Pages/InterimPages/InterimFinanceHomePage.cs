using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimFinanceHomePage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Finance";

        protected override string Linktext => "Finance";

        public InterimFinanceHomePage(ScenarioContext context, bool navigate) : base(context, navigate) { }
    }
}

