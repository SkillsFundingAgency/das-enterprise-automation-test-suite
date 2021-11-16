using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class TermsOfUsePage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Terms of use of service";
        protected override By ContinueButton => By.CssSelector("#main-content button.govuk-button");

        public TermsOfUsePage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeHomePage AcceptTermsAndConditionForPositiveMatch(bool IsConfirmYourApprenticeLinkDisplayed)
        {
            Continue();
            return new ApprenticeHomePage(_context, IsConfirmYourApprenticeLinkDisplayed);
        }

        public ApprenticeHomePageNegativeMatch AcceptTermsAndConditionForNegativeMatch()
        {
            Continue();
            return new ApprenticeHomePageNegativeMatch(_context);
        }
    }
}
