using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.ProviderLogin.Service.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ApprovalsProviderHomePage : ProviderHomePage
    {
        protected By ApprenticeRequestsLink => By.LinkText("Apprentice requests");

        public ApprovalsProviderHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)  { }

        public ProviderManageYourApprenticesPage GoToProviderManageYourApprenticePage()
        {
            formCompletionHelper.ClickElement(ProviderManageYourApprenticesLink);
            return new ProviderManageYourApprenticesPage(_context);
        }

        public ProviderNotificationSettingsPage GoToProviderNotificationSettingsPage()
        {
            formCompletionHelper.ClickElement(NotificationSettingsLink);
            return new ProviderNotificationSettingsPage(_context);
        }

        public ProviderOrganisationsAndAgreementsPage GoToOrganisationsAndAgreementsPage()
        {
            formCompletionHelper.ClickElement(OrganisationsAndAgreementsLink);
            return new ProviderOrganisationsAndAgreementsPage(_context);
        }

        public ProviderAddApprenticeDetailsViaSelectJourneyPage GotoSelectJourneyPage()
        {
            formCompletionHelper.ClickElement(AddNewApprenticesLink);
            return new ProviderAddApprenticeDetailsViaSelectJourneyPage(_context);
        }

        public ProviderReserveFundingForNonLevyEmployersPage GoToProviderGetFunding()
        {
            formCompletionHelper.ClickElement(GetFundingLink);
            return new ProviderReserveFundingForNonLevyEmployersPage(_context);
        }

        public ProviderAccessDeniedPage GoToProviderGetFundingGoesToAccessDenied()
        {
            formCompletionHelper.ClickElement(GetFundingLink);
            return new ProviderAccessDeniedPage(_context);
        }

        public ProviderFundingForNonLevyEmployersPage GoToManageYourFunding()
        {
            formCompletionHelper.ClickElement(ManageYourFundingLink);
            return new ProviderFundingForNonLevyEmployersPage(_context);
        }

        public ProviderApprenticeRequestsPage GoToApprenticeRequestsPage()
        {
            formCompletionHelper.ClickElement(ApprenticeRequestsLink);
            return new ProviderApprenticeRequestsPage(_context);
        }

        public ProviderAccessDeniedPage AddNewApprenticesGoesToAccessDenied()
        {
            formCompletionHelper.ClickElement(AddNewApprenticesLink);
            return new ProviderAccessDeniedPage(_context);
        }
    }
}