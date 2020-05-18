using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages
{
    public class InvitationSentPage : InterimHomeBasePage
    {
        protected override string PageTitle => "Invitation sent";

        protected override By PageHeader => By.CssSelector("h1");

        public InvitationSentPage(ScenarioContext context) : base(context, false) { }
    }
}
