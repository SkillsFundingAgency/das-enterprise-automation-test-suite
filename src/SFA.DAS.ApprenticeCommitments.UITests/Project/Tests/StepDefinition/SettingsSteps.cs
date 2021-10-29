using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class SettingsSteps : BaseSteps
    {
        private ScenarioContext _context;

        public SettingsSteps(ScenarioContext context) : base(context)  => _context = context;

        [Given(@"an apprentice has a confirmed account")]
        public void GivenAnApprenticeHasAConfirmedAccount() => createAccountStepsHelper.CreateAccountViaApiAndConfirmApprenticeshipViaDb();

        [Then(@"an apprentice can change their email")]
        public void ThenAnApprenticeCanChangeTheirEmail() => GetTopBannerSettingsPage().NavigateToChangeYourEmailAddress().UpdateEmailAddress();

        [Then(@"an apprentice can change their personal details")]
        public void ThenAnApprenticeCanChangeTheirPersonalDetails() => GetTopBannerSettingsPage().NavigateToChangeYourPersonalDetails().UpdateApprenticeName();

        [Then(@"an apprentice can change their password")]
        public void ThenAnApprenticeCanChangeTheirPassword() => GetTopBannerSettingsPage().NavigateToChangeYourPassword().UpdatePassword();

        private TopBannerSettingsPage GetTopBannerSettingsPage() => new TopBannerSettingsPage(_context);

        [Then(@"an apprentice can not change their personal details")]
        public void ThenAnApprenticeCanNotChangeTheirPersonalDetails()
        {
            var page = new CreateMyApprenticeshipAccountPage(_context);

            var expected = page.AccountSettingList();

            var actual = new CreateMyApprenticeshipAccountPage(_context).GetAccountSettingMenuList();

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
