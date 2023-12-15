using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public class InterimApprenticesHomePage(ScenarioContext context, bool gotourl) : InterimEmployerBasePage(context, true, gotourl)
    {
        protected override string PageTitle => "Apprentices";

        protected override string Linktext => "Apprentices";
    }
}