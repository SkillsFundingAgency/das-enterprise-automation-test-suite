using Azure.Core;
using OpenQA.Selenium;
using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class EmployerVacancySearchResultPage(ScenarioContext context) : VacancySearchResultPage(context)
    {
        protected override string PageTitle => "Your adverts";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        private static By Applicant => By.CssSelector("a[data-label='application_review']");
        private static By ApplicantStatus => By.CssSelector("td[data-label='Status'] > strong");
        public CreateAnApprenticeshipAdvertOrVacancyPage CreateAnApprenticeshipAdvertPage()
        {
            DraftVacancy();
            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }

        public ApprenticeshipTrainingPage GoToApprenticeshipTrainingPage()
        {
            DraftVacancy();
            return new ApprenticeshipTrainingPage(context);
        }

        public PreviewYourAdvertOrVacancyPage GoToVacancyPreviewPart2Page()
        {
            DraftVacancy();
            return new PreviewYourAdvertOrVacancyPage(context);
        }
        public ManageApplicantPage NavigateToManageApplicant()
        {
            GoToVacancyManagePage();
            if(IsFoundationAdvert)
            {
                CheckFoundationTag();
            }
            formCompletionHelper.Click(Applicant);
            return new ManageApplicantPage(context);
        }
        public void CheckApplicantStatus(string status)
        {
            GoToVacancyManagePage();
            if (IsFoundationAdvert)
            {
                CheckFoundationTag();
            }
            pageInteractionHelper.CheckText(ApplicantStatus, status);
        }
        public ViewVacancyPage NavigateToViewAdvertPage()
        {
            GoToVacancyManagePage();
            string linkTest = isRaaEmployer ? "View advert" : "View vacancy";
            formCompletionHelper.ClickLinkByText(linkTest);

            return new ViewVacancyPage(context);
        }
    }
}