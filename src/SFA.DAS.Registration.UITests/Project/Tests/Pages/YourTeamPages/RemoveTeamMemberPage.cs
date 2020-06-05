using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages
{
    public class RemoveTeamMemberPage : RegistrationBasePage
    {
        protected override string PageTitle => "Remove team member";
        private readonly ScenarioContext _context;

        #region Locators
        private By YesRemoveNowButton => By.Id("remove_team_member");
        #endregion

        public RemoveTeamMemberPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public YourTeamPage ClickYesRemoveNowButton()
        {
            formCompletionHelper.Click(YesRemoveNowButton);
            return new YourTeamPage(_context);
        }
    }
}
