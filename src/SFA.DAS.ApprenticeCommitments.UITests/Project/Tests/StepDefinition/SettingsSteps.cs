using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class SettingsSteps : BaseSteps
    {
        private ScenarioContext _context;
        private ApprenticeOverviewPage _apprenticeOverviewPage;

        public SettingsSteps(ScenarioContext context) : base(context)  => _context = context;

        [Given(@"an apprentice has a confirmed account")]
        public void GivenAnApprenticeHasAConfirmedAccount() => _apprenticeOverviewPage = createAccountStepsHelper.CreateAccountViaApiAndConfirmApprenticeshipViaDb();

        [Then(@"an apprentice can change their email")]
        public void ThenAnApprenticeCanChangeTheirEmail() => _apprenticeOverviewPage.NavigateToChangeYourEmailAddress().UpdateEmailAddress();

        [Then(@"an apprentice can change their personal details")]
        public void ThenAnApprenticeCanChangeTheirPersonalDetails() => _apprenticeOverviewPage.NavigateToChangeYourPersonalDetails().UpdateApprenticeName();

        [Then(@"an apprentice can change their password")]
        public void ThenAnApprenticeCanChangeTheirPassword() => _apprenticeOverviewPage.NavigateToChangeYourPassword().UpdatePassword();

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
