using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class StartPage : ApprenticeCommitmentsBasePage
    {

        protected override string PageTitle => "Confirm my apprenticeship details";
        protected override By AcceptCookieButton => By.CssSelector(".das-cookie-banner__button-accept");
        private By StartNowButton => By.CssSelector(".govuk-button");

        public StartPage(ScenarioContext context, bool shouldCookieBannerBePresent = true) : base(context)
        {
            if (shouldCookieBannerBePresent)
                AcceptCookies();
        }

        public SignIntoMyApprenticeshipPage CTAOnStartPageToSignIn()
        {
            formCompletionHelper.ClickButtonByText(StartNowButton, "Start now");
            return new SignIntoMyApprenticeshipPage(context);
        }
    }
}
