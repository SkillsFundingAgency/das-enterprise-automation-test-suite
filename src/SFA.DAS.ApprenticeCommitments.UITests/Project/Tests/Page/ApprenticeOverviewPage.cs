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
        private static By SectionStatus(string sectionName) => By.XPath($"//p[contains(text(),'{sectionName}')]/following-sibling::strong");
        private static By AllSectionsConfirmedSuccessTickIcon => By.XPath("//span[@class='app-notification-banner__icon das-text--success-icon']");
        private static By AppreticeshipConfirmBannerText => By.XPath("//div[contains(@class,'app-notification-banner')]/div");
        protected static By FeedbackLink => By.CssSelector(".app-navigation__link[href*='feedback']");
        private static By DaysToConfirmWarningText => By.CssSelector(".govuk-warning-text__text");
        private static By OverviewPageSubTextBelowPageTitle => By.XPath("(//h1//following-sibling::p)[1]");
        private static By OverviewPageWarningIcon => By.CssSelector(".govuk-warning-text__icon");
        private static By OverviewPageWarningText => By.CssSelector(".govuk-warning-text__text");
        private static By OverviewPageTopSubTextAfterWarning => By.XPath("(//h1//following-sibling::p)[2]");

        public ApprenticeOverviewPage(ScenarioContext context, bool verifypage = true) : base(context, verifypage)
        {
            VerifyPage(TopBlueBannerHeader, $"Welcome, {objectContext.GetFirstName()} {objectContext.GetLastName()}");

            if (verifypage)
                MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(HelpTopNavigationLink),
                () => VerifyPage(OverviewPageSubTextBelowPageTitle, OverviewPageHelper.OverviewPageTopSubText1),
                () => VerifyPage(OverviewPageWarningIcon),
                () => VerifyPage(OverviewPageWarningText, OverviewPageHelper.OverviewPageTopSubText2),
                () => VerifyPage(OverviewPageTopSubTextAfterWarning, OverviewPageHelper.OverviewPageTopSubText3)
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

        public OverallApprenticeshipConfirmedPage ConfirmOverallApprenticeship()
        {
            ClickConfirmYourApprenticeshipLink();
            return new OverallApprenticeshipConfirmedPage(context);
        }

        public string GetTheSectionStatus(string sectionName) => pageInteractionHelper.GetText(SectionStatus(sectionName)).Replace("\r\n", " ");

        public ApprenticeOverviewPage VerifyTopBannerOnOverviewPageBeforeOverallConfirmation()
        {
            VerifyElement(AllSectionsConfirmedSuccessTickIcon);
            VerifyElement(AppreticeshipConfirmBannerText, OverviewPageHelper.AllSectionsConfirmedConfirmationTextBeforeOVerallConfirmation); ;
            return this;
        }

        public ApprenticeOverviewPage VerifyHeaderSummaryOnApprenticeOverviewPageAfterApprenticeshipConfirm()
        {
            VerifyElement(PageHeader, PageTitleAfterConfirmation);
            VerifyElement(AppreticeshipConfirmBannerText, OverviewPageHelper.OverallConfirmationText);
            return this;
        }

        public ApprenticeOverviewPage VerifyDaysToConfirmWarning() { VerifyElement(DaysToConfirmWarningText, OverviewPageHelper.OverviewPageTopSubText2); return this; }

        private void ClickYourEmployerLink() => formCompletionHelper.ClickLinkByText(OverviewPageHelper.Section1);

        private void ClickYourProviderLink() => formCompletionHelper.ClickLinkByText(OverviewPageHelper.Section2);

        private void ClickYourApprenticeshipDetailsLink() => formCompletionHelper.ClickLinkByText(OverviewPageHelper.Section3);

        private void ClickHowYourApprenticeshipWillBeDeliveredLink() => formCompletionHelper.ClickLinkByText(OverviewPageHelper.Section4);

        private void ClickRolesAndResponsibilitiesLink() => formCompletionHelper.ClickLinkByText(OverviewPageHelper.Section5);

        private void ClickConfirmYourApprenticeshipLink() => formCompletionHelper.ClickLinkByText(OverviewPageHelper.Section6);
    }
}
