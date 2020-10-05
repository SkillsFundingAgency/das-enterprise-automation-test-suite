using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimApprenticesAccessDeniedPage : InterimApprenticesHomePage
    {
        protected override string PageTitle => "Access denied";

        public InterimApprenticesAccessDeniedPage(ScenarioContext context) : base(context, true) { }
        
    }
}