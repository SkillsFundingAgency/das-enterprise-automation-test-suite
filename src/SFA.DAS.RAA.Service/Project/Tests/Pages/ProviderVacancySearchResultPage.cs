using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ProviderVacancySearchResultPage(ScenarioContext context) : VacancySearchResultPage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected override string PageTitle => "Your vacancies";

        private static By Applications => By.CssSelector("a.govuk-link[href*='applications']");

        public ManageApplicantPage NavigateToManageApplicant()
        {
            GoToVacancyManageApplicantsPage($"{rAAV2DataHelper.CandidateFullName}");

            return new ManageApplicantPage(context);
        }

        public ViewVacancyPage NavigateToViewAdvertPage()
        {
            GoToVacancyManagePage();

            string linkTest = isRaaV2Employer ? "View advert" : "View vacancy";

            formCompletionHelper.ClickLinkByText(linkTest);

            return new ViewVacancyPage(context);
        }

        public ManageShareApplicationsPage NavigateToManageApplicants()
        {
            GoToVacancyManageApplicantsPage("Share multiple applications with employer");

            return new ManageShareApplicationsPage(context);
        }

        public ManageMultiApplicationsUnsuccessfulPage NavigateToManageAllApplicants()
        {
            GoToVacancyManageApplicantsPage("Make multiple applications unsuccessful");

            return new ManageMultiApplicationsUnsuccessfulPage(context);
        }

        private void GoToVacancyManageApplicantsPage(string linkText)
        {
            GoToVacancyManagePage();

            formCompletionHelper.ClickLinkByText(Applications, linkText);
        }
    }
}
