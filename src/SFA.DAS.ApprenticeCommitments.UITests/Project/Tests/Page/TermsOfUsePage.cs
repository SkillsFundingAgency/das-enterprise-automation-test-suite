using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class TermsOfUsePage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => Config.PageTitles.TermsOfUse;
        protected override By ContinueButton => By.CssSelector("#main-content button.govuk-button");
        private static By CheckboxLocator => By.Id("TermsOfUseAccepted");

        public TermsOfUsePage(ScenarioContext context) : base(context)
            => AssertTopNavigationLinksNotToBePresent();

        public static class Config
        {
            public static class PageTitles
            {
                public const string TermsOfUse = "Accept the terms and conditions";
            }
        }

        public void AcceptTerms()
        {
            PageInteractionHelper.TickCheckbox(CheckboxLocator);
            Continue();

        }

        public ApprenticeHomePage AcceptTermsAndConditionToPositiveMatch(bool isConfirmYourApprenticeLinkDisplayed)
        {
            AcceptTerms();
            return new ApprenticeHomePage(context, isConfirmYourApprenticeLinkDisplayed);
        }

        public ApprenticeHomePageNegativeMatch AcceptTermsAndConditionToNegativeMatch()
        {
            AcceptTerms();
            return new ApprenticeHomePageNegativeMatch(context);
        }
    }
}