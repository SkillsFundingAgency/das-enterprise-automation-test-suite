using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeHomePageNegativeMatch : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => $"Check your details";

        public ApprenticeHomePageNegativeMatch(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage(TopBlueBannerHeader, $"{objectContext.GetFirstName()} {objectContext.GetLastName()}");
            AssertTopNavigationLinksNotToBePresent();
            AssertNotificationBanner();
        }

        public ChangeYourPersonalDetailsPage GoToChangeYourPersonalDetailsPage()
        {
            formCompletionHelper.ClickLinkByText("update your details");
            return new ChangeYourPersonalDetailsPage(_context);
        }

        private void AssertTopNavigationLinksNotToBePresent()
        {
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(HomeTopNavigationLink), "Home Top navigation link is present when it should not for a Negative match Acccount");
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(CMADTopNavigationLink), "CMAD Top navigation link is present when it should not for a Negative match Acccount");
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(HelpTopNavigationLink), "Help Top navigation link is present when it should not for a Negative match Acccount");
        }

        private void AssertNotificationBanner()
        {
            VerifyNotificationBannerHeader("There seems to be a problem, we cannot find your apprenticeship.");
            VerifyNotificationBannerContent("Check your name and date of birth details. If they are incorrect, please update your details.");
        }
    }
}
