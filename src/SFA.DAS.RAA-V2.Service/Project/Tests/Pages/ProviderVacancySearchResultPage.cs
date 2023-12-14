using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ProviderVacancySearchResultPage(ScenarioContext context) : VacancySearchResultPage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected override string PageTitle => "Your vacancies";

        private static By Applicant => By.CssSelector("tbody tr:nth-child(1) td:nth-child(1)");

        public ManageApplicantPage NavigateToManageApplicant()
        {
            GoToVacancyManagePage();
            formCompletionHelper.Click(Applicant);
            return new ManageApplicantPage(context);
        }
        public ViewVacancyPage NavigateToViewAdvertPage()
        {
            GoToVacancyManagePage();
            string linkTest = isRaaV2Employer ? "View advert" : "View vacancy";
            formCompletionHelper.ClickLinkByText(linkTest);

            return new ViewVacancyPage(context);
        }
    }
}
