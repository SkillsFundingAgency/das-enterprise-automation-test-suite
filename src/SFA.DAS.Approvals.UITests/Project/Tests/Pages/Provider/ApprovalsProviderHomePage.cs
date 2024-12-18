using System.Linq;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ApprovalsProviderHomePage(ScenarioContext context, bool navigate = false) : ProviderHomePage(context, navigate)
    {
        protected static By ApprenticeRequestsLink => By.LinkText("Apprentice requests");
        protected static By OrganisationsAndAgreementsLink => By.LinkText("Organisations and agreements");
        protected static By DfeResearchPageTitle => By.ClassName("QuestionText");
        protected static By MoreNavigationLink => By.XPath("//a[@class='das-navigation__priority-button' and text()='More']");
        protected static By SettingsNavigationLink => By.XPath("//a[@class='das-user-navigation__link' and text()='Settings']");
        protected static By HelpFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Help']");
        protected static By FeedbackFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Feedback ']");
        protected static By PrivacyFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Privacy']");
        protected static By CookiesFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Cookies']");
        protected static By TermsOfUseFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Terms of use']");

        public ProviderManageYourApprenticesPage GoToProviderManageYourApprenticePage()
        {
            formCompletionHelper.ClickElement(ProviderManageYourApprenticesLink);
            return new ProviderManageYourApprenticesPage(context);
        }

        public ProviderNotificationSettingsPage GoToProviderNotificationSettingsPage()
        {
            formCompletionHelper.ClickElement(SettingsNavigationLink);
            formCompletionHelper.ClickElement(NotificationSettingsLink);
            return new ProviderNotificationSettingsPage(context);
        }

        public ProviderOrganisationsAndAgreementsPage GoToProviderOrganisationsAndAgreementsPage()
        {
            formCompletionHelper.ClickElement(MoreNavigationLink);
            formCompletionHelper.ClickElement(OrganisationsAndAgreementsLink);
            return new ProviderOrganisationsAndAgreementsPage(context);
        }

        public ManageApprenticeshipsServiceHelpPage GoToManageApprenticeshipsServiceHelpPage()
        {
            formCompletionHelper.ClickElement(HelpFooterLink);
            return new ManageApprenticeshipsServiceHelpPage(context);
        }

        public ApprovalsProviderHomePage VerifyProviderFooterFeedbackPage()
        {
            var webDriver = context.GetWebDriver();
            var originalTab = webDriver.CurrentWindowHandle;

            formCompletionHelper.ClickElement(FeedbackFooterLink);
            var newTabHandle = webDriver.WindowHandles.First(handle => handle != originalTab);
            webDriver.SwitchTo().Window(newTabHandle);

            pageInteractionHelper.GetUrl().Contains("dferesearch");
            tabHelper.OpenInNewTab(UrlConfig.Provider_BaseUrl);
            return new ApprovalsProviderHomePage(context);
        }

        public ProviderPrivacyPage GoToProviderFooterPrivacyPage()
        {
            formCompletionHelper.ClickElement(PrivacyFooterLink);
            return new ProviderPrivacyPage(context);
        }

        public ProviderCookiesPage GoToProviderFooterCookiesPage()
        {
            formCompletionHelper.ClickElement(CookiesFooterLink);
            return new ProviderCookiesPage(context);
        }

        public ProviderTermsOfUsePage GoToProviderFooterTermsOfUsePage()
        {
            formCompletionHelper.ClickElement(TermsOfUseFooterLink);
            return new ProviderTermsOfUsePage(context);
        }

        public ProviderAddApprenticeDetailsEntryMothod GotoSelectJourneyPage()
        {
            AddNewApprentices();
            return new ProviderAddApprenticeDetailsEntryMothod(context);
        }

        public ProviderAccessDeniedPage GotoSelectJourneyPageGoesToAccessDenied()
        {
            AddNewApprentices();
            return new ProviderAccessDeniedPage(context);
        }

        public ProviderAddEmployerStartPage GotoAddNewEmployerStartPage()
        {
            ClickAddAnEmployerLink();
            return new ProviderAddEmployerStartPage(context);
        }

        public ProviderAccessDeniedPage GotoAddNewEmployerStartPageGoesToAccessDenied()
        {
            ClickAddAnEmployerLink();
            return new ProviderAccessDeniedPage(context);
        }


        public ViewEmpAndManagePermissionsPage GotoViewEmpAndManagePermissionsPage()
        {
            ClickViewEmployersAndManagePermissionsLink();
            return new ViewEmpAndManagePermissionsPage(context);
        }

        public ProviderCreateAVacancyPage GoToProviderRecruitApprenticesPage()
        {
            formCompletionHelper.ClickElement(ProviderRecruitApprenticesLink);
            return new ProviderCreateAVacancyPage(context);
        }

        public ProviderYourStandardsAndTrainingVenuesPage NavigateToYourStandardsAndTrainingVenuesPage()
        {
            formCompletionHelper.ClickElement(YourStandardsAndTrainingVenues);
            return new ProviderYourStandardsAndTrainingVenuesPage(context);
        }

        public ProviderAPIListPage NavigateToDeveloperAPIsPage()
        {
            formCompletionHelper.ClickElement(DeveloperAPIsLink);
            return new ProviderAPIListPage(context);
        }

        public ApimAccessDeniedPage NavigateToDeveloperAPIsPageGoesToApimAccessDenied()
        {
            formCompletionHelper.ClickElement(DeveloperAPIsLink);
            return new ApimAccessDeniedPage(context);
        }

        public ProviderYourFeebackPage NavigateToYourFeedback()
        {
            formCompletionHelper.Click(YourFeedback);
            return new ProviderYourFeebackPage(context);
        }

        public ProviderViewEmployerRequestsForTrainingPage NavigateToViewEmployerRequestsForTrainingPage()
        {
            formCompletionHelper.Click(ViewEmployerRequestsForTraining);
            return new ProviderViewEmployerRequestsForTrainingPage(context);
        }

        public ProviderReserveFundingForNonLevyEmployersPage GoToProviderGetFunding()
        {
            formCompletionHelper.ClickElement(GetFundingLink);
            return new ProviderReserveFundingForNonLevyEmployersPage(context);
        }

        public ProviderAccessDeniedPage GoToProviderGetFundingGoesToAccessDenied()
        {
            formCompletionHelper.ClickElement(GetFundingLink);
            return new ProviderAccessDeniedPage(context);
        }

        public ProviderFundingForNonLevyEmployersPage GoToManageYourFunding()
        {
            formCompletionHelper.ClickElement(ManageYourFundingLink);
            return new ProviderFundingForNonLevyEmployersPage(context);
        }

        public ProviderApprenticeRequestsPage GoToApprenticeRequestsPage()
        {
            formCompletionHelper.ClickElement(ApprenticeRequestsLink);
            return new ProviderApprenticeRequestsPage(context);
        }

        public ProviderAccessDeniedPage AddNewApprenticesGoesToAccessDenied()
        {
            AddNewApprentices();
            return new ProviderAccessDeniedPage(context);
        }

        public ProviderApprenticeshipIndicativeEarningsReportPage GoToApprenticeshipIndicativeEarningsReportPage()
        {
            formCompletionHelper.ClickElement(AppsIndicativeEarningsReport);
            return new ProviderApprenticeshipIndicativeEarningsReportPage(context);
        }

        private void AddNewApprentices() => formCompletionHelper.ClickElement(AddNewApprenticesLink);
    }
}