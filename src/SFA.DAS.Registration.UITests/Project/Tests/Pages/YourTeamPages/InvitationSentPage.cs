using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages
{
    public class InvitationSentPage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Invitation sent";
        protected override By PageHeader => By.CssSelector("h1");
        protected override string Linktext => "Home";

        public InvitationSentPage(ScenarioContext context) : base(context, false) => VerifyPage();
    }
}
