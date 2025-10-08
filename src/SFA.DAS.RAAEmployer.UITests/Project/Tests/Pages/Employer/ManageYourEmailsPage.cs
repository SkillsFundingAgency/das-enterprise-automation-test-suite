
using Azure.Core;
using HtmlAgilityPack;
using OpenQA.Selenium;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAEmployer.UITests.Project.Tests.Pages.Employer
{
    public class ManageYourEmailsPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Manage your advert notifications";
        private static By NotificationBannerTitleLocator => By.CssSelector(".govuk-notification-banner__title");
        private static By NotificationBannerHeadingLocator => By.CssSelector(".govuk-notification-banner__heading");

        public ManageYourEmailsPage SelectAndSaveEmailPreferences()
        {
            SelectRadioOptionByForAttribute("approved-rejected-mine");
            SelectRadioOptionByForAttribute("applications-mine");
            SelectRadioOptionByForAttribute("notify-now");

            formCompletionHelper.ClickButtonByText(SaveAndContinueButton, "Save settings");
            return this;
        }

        public ManageYourEmailsPage VerifyEmailSettingsConfirmationBanner()
        {
            var ExpectedBannerTitle = "Success";
            var ExpectedBannerHeading = "Advert notification settings saved.";
            pageInteractionHelper.VerifyText(NotificationBannerTitleLocator, ExpectedBannerTitle);
            pageInteractionHelper.VerifyText(NotificationBannerHeadingLocator, ExpectedBannerHeading);
            return this;
        }
    }
}
