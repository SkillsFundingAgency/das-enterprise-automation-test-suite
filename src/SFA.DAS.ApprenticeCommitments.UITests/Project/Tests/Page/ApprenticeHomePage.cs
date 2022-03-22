using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeHomePage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => $"Welcome, {objectContext.GetFirstName()} {objectContext.GetLastName()}";
        private By ConfirmYourApprenticeshipNowLink => By.XPath("//a[text()='Confirm your apprenticeship now']");
        private By HelpAndSupportSectionLink => By.XPath("//a[text()='help and support section']");
        private By CompleteStatusSelector => By.CssSelector("#dashboard-section strong.govuk-tag--green");
        private By InCompleteStatusSelector => By.CssSelector("#dashboard-section strong.govuk-tag--yellow");

        public ApprenticeHomePage(ScenarioContext context, bool verifyConfirmYourApprenticeLink = true) : base(context)
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(TopBlueBannerHeader, $"{objectContext.GetFirstName()} {objectContext.GetLastName()}"),
                () => { if (verifyConfirmYourApprenticeLink) VerifySucessNotification(); return true; }
            });
        }

        public bool VerifyNotificationBannerIsNotDisplayed() => pageInteractionHelper.IsElementDisplayed(NotificationBanner);

        public ApprenticeHomePage VerifySucessNotification()
        {
            VerifyNotificationBannerHeader("Success");
            VerifyNotificationBannerContent("You have created an account and we have found your apprenticeship.");
            VerifyElement(ConfirmYourApprenticeshipNowLink);
            return this;
        }

        public ApprenticeOverviewPage NavigateToOverviewPageFromLinkOnTheHomePage()
        {
            formCompletionHelper.Click(ConfirmYourApprenticeshipNowLink);
            return new ApprenticeOverviewPage(context, false);
        }

        public HelpAndSupportPage NavigateToHelpAndSupportPageWithTheLinkOnHomePage()
        {
            formCompletionHelper.Click(HelpAndSupportSectionLink);
            return new HelpAndSupportPage(context);
        }

        public ApprenticeHomePage VerifyCMADSectionStatusToBeCompleteOnHomePage() { VerifyElement(CompleteStatusSelector); return this; }

        public ApprenticeHomePage VerifyCMADSectionStatusToBeInCompleteOnHomePage() { VerifyElement(InCompleteStatusSelector); return this; }
    }
}
