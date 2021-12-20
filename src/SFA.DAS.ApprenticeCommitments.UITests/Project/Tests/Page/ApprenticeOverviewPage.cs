using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public partial class ApprenticeOverviewPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Confirm my apprenticeship details";
        private string PageTitleAfterConfirmation => "Your apprenticeship details";
        private By SectionStatus(string sectionName) => By.XPath($"//h3[contains(text(),'{sectionName}')]/following-sibling::strong");
        private By AppreticeshipConfirmBannerHeader => By.XPath("//span[@class='app-notification-banner__icon das-text--success-icon']");
        private By AppreticeshipConfirmBannerText => By.XPath("//div[contains(@class,'app-notification-banner')]/div");
        private By ConfirmMyApprenticeshipButton => By.XPath("//button[text()='Confirm my apprenticeship']");
        private By HelpAndSupportSection => By.XPath("//h2[text()='Help and support']");
        private By DaysToConfirmWarningText => By.CssSelector(".govuk-warning-text__text");

        public ApprenticeOverviewPage(ScenarioContext context, bool verifypage = true) : base(context, verifypage)
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(TopBlueBannerHeader, $"Welcome, {objectContext.GetFirstName()} {objectContext.GetLastName()}"),
                () => VerifyPage(HelpAndSupportSection)
            });
        }

        public ConfirmYourEmployerPage GoToConfirmYourEmployerPage()
        {
            ClickYourEmployerLink();
            return new ConfirmYourEmployerPage(context);
        }

        public AlreadyConfirmedEmployerPage GoToAlreadyConfirmedEmployerPage()
        {
            ClickYourEmployerLink();
            return new AlreadyConfirmedEmployerPage(context);
        }

        public ConfirmYourTrainingProviderPage GoToConfirmYourTrainingProviderPage()
        {
            ClickYourProviderLink();
            return new ConfirmYourTrainingProviderPage(context);
        }

        public AlreadyConfirmedTrainingProviderPage GoToAlreadyConfirmedTrainingProviderPage()
        {
            ClickYourProviderLink();
            return new AlreadyConfirmedTrainingProviderPage(context);
        }

        public ConfirmYourApprenticeshipDetailsPage GoToConfirmYourApprenticeshipDetailsPage()
        {
            ClickYourApprenticeshipDetailsLink();
            return new ConfirmYourApprenticeshipDetailsPage(context);
        }

        public AlreadyConfirmedApprenticeshipDetailsPage GoToAlreadyConfirmedApprenticeshipDetailsPage()
        {
            ClickYourApprenticeshipDetailsLink();
            return new AlreadyConfirmedApprenticeshipDetailsPage(context);
        }

        public ConfirmRolesAndResponsibilitiesPage1of3 GoToConfirmRolesAndResponsibilitiesPage()
        {
            ClickRolesAndResponsibilitiesLink();
            return new ConfirmRolesAndResponsibilitiesPage1of3(context);
        }

        public AlreadyConfirmedRolesAndResponsibilitiesPage GoToAlreadyConfirmedRolesAndResponsibilitiesPage()
        {
            ClickRolesAndResponsibilitiesLink();
            return new AlreadyConfirmedRolesAndResponsibilitiesPage(context);
        }

        public ConfirmHowYourApprenticeshipWillBeDeliveredPage GoToConfirmHowYourApprenticeshipWillBeDeliveredPage()
        {
            ClickHowYourApprenticeshipWillBeDeliveredLink();
            return new ConfirmHowYourApprenticeshipWillBeDeliveredPage(context);
        }

        public AlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage GoToAlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage()
        {
            ClickHowYourApprenticeshipWillBeDeliveredLink();
            return new AlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage(context);
        }

        public string GetTheSectionStatus(string sectionName) => pageInteractionHelper.GetText(SectionStatus(sectionName)).Replace("\r\n", " ");

        public TransactionCompletePage ConfirmYourApprenticeshipFromTheTopBanner()
        {
            VerifyPage(AppreticeshipConfirmBannerHeader);
            VerifyElement(AppreticeshipConfirmBannerText, "Your apprenticeship is now ready to confirm");
            formCompletionHelper.Click(ConfirmMyApprenticeshipButton);
            return new TransactionCompletePage(context);
        }

        public void VerifyPageAfterApprenticeshipConfirm()
        {
            VerifyElement(PageHeader, PageTitleAfterConfirmation);
            VerifyElement(AppreticeshipConfirmBannerText, "You have completed the confirmation of your apprenticeship. Your employer and training provider will contact you shortly.");
        }

        public ApprenticeOverviewPage VerifyDaysToConfirmWarning() { VerifyElement(DaysToConfirmWarningText, "You have 14 days to confirm your apprenticeship details"); return this; }

        private void ClickYourEmployerLink() => formCompletionHelper.ClickLinkByText(SectionHelper.Section1);

        private void ClickYourProviderLink() => formCompletionHelper.ClickLinkByText(SectionHelper.Section2);

        private void ClickYourApprenticeshipDetailsLink() => formCompletionHelper.ClickLinkByText(SectionHelper.Section3);

        private void ClickHowYourApprenticeshipWillBeDeliveredLink() => formCompletionHelper.ClickLinkByText(SectionHelper.Section4);

        private void ClickRolesAndResponsibilitiesLink() => formCompletionHelper.ClickLinkByText(SectionHelper.Section5);
    }
}
