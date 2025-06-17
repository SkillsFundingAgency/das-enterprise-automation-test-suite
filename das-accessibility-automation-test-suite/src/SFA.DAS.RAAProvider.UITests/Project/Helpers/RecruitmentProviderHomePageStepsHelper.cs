using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.RAAProvider.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Helpers
{
    public class RecruitmentProviderHomePageStepsHelper(ScenarioContext context)
    {
        private FormCompletionHelper formCompletionHelper;

        private static By RecruitApprenticesLink => By.CssSelector("a.das-navigation__link[href*='recruit']");


        public RecruitmentHomePage GoToRecruitmentProviderHomePage(bool newTab)
        {
            new ProviderHomePageStepsHelper(context).GoToProviderHomePage(newTab);

            return new RecruitmentHomePage(context, true);
        }
        public ReportsPage GoToReportsPage()
        {
            var recruitmentHomePage = new RecruitmentHomePage(context);
            return recruitmentHomePage.GoToReportsPage();
        }
        public RecruitmentHomePage NavigateToRecruitmentHomePage()
        {
            formCompletionHelper.ClickElement(RecruitApprenticesLink);
            return new RecruitmentHomePage(context);
        }

        public ManageYourRecruitmentEmailsPage GoToManageYourRecruitmentEmailsPage(bool newTab = false)
        {
            var recruitmentHomePage = GoToRecruitmentProviderHomePage(newTab);
            return recruitmentHomePage.GoToManageYourRecruitmentEmailsPage();
        }
        public ApprenticeRequestsPage GoToApprenticeRequestsPage(bool newTab = false)
        {
            var recruitmentHomePage = GoToRecruitmentProviderHomePage(newTab);
            return recruitmentHomePage.NavigateToApprenticeRequestsPage();
        }
        public ManageFundingPage GoToManageFundingPage(bool newTab = false)
        {
            var recruitmentHomePage = GoToRecruitmentProviderHomePage(newTab);
            return recruitmentHomePage.NavigateToManageFundingPage();
        }
        public ManageYourApprenticePage GoToManageYourApprenticesPage(bool newTab = false)
        {
            var recruitmentHomePage = GoToRecruitmentProviderHomePage(newTab);
            return recruitmentHomePage.NavigateToManageYourApprenticesPage();
        }
        public OrganisationsAndAgreementsPage GoToOrganisationsAndAgreementsPage(bool newTab = false)
        {
            var recruitmentHomePage = GoToRecruitmentProviderHomePage(newTab);
            return recruitmentHomePage.NavigateToOrganisationsAndAgreementsPage();
        }
        public NotificationsSettingsPage GoToNotificationsViaSettingsPage(bool newTab = false)
        {
            var recruitmentHomePage = GoToRecruitmentProviderHomePage(newTab);
            return recruitmentHomePage.GoToNotificationsSettingsPage();
        }
        public ChangeYourSignInDetailsPage GoToChangeYourSignInDetailsPage(bool newTab = false)
        {
            var recruitmentHomePage = GoToRecruitmentProviderHomePage(newTab);
            return recruitmentHomePage.GoToChangeYourSignInDetailsPage();
        }
    }
}