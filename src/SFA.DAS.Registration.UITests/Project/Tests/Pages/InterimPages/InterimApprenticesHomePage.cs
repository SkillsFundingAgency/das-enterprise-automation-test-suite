using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimApprenticesHomePage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Apprentices";

        protected override string Linktext => "Apprentices";

        public InterimApprenticesHomePage(ScenarioContext context, bool navigate) : base(context, navigate) { }
    }
}

