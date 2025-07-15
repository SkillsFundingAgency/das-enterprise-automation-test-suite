using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ProviderVacancySearchResultPage(ScenarioContext context) : VacancySearchResultPage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected override string PageTitle => "Your vacancies";

        private static By Applications => By.CssSelector("a.govuk-link[href*='applications']");

       
        public ManageApplicantPage NavigateToManageApplicant(string applicationid = null)
        {
            GoToVacancyManageApplicantsPage(applicationid);

            if (string.IsNullOrEmpty(applicationid))
            {
                applicationid = GetApplicationIdFromManageApplicantsPage();
            }

            formCompletionHelper.Click(By.Id($"application-id-{applicationid}"));
            if(IsFoundationAdvert)
            {
                CheckFoundationTag();
            }

            return new ManageApplicantPage(context);
        }

        private string GetApplicationIdFromManageApplicantsPage()
        {
            var applicationIdIdentifier = pageInteractionHelper.FindElement(By.CssSelector("a[id^='application-id-']"));
            var applicationIdNumber = applicationIdIdentifier?.GetDomAttribute("id");

            if (!string.IsNullOrEmpty(applicationIdNumber) && applicationIdNumber.StartsWith("application-id-"))
            {
                return applicationIdNumber.Replace("application-id-", "");
            }

            throw new InvalidOperationException("Application ID not found or in unexpected format.");
        }

        public ViewVacancyPage NavigateToViewAdvertPage()
        {
            GoToVacancyManagePage();

            string linkTest = isRaaEmployer ? "View advert" : "View vacancy";

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

        private void GoToVacancyManageApplicantsPage(string applicationid)
        {
            GoToVacancyManagePage();

            if (!string.IsNullOrEmpty(applicationid))
            {
                formCompletionHelper.ClickLinkByText(Applications, applicationid);
            }
        }

        public CreateAnApprenticeshipAdvertOrVacancyPage CreateAnApprenticeshipAdvertPage()
        {
            DraftVacancy();
            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }
    }
}
