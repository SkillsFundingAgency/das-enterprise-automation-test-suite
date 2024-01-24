using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EmployerVacancySearchResultPage(ScenarioContext context) : VacancySearchResultPage(context)
    {
        protected override string PageTitle => "Your adverts";

        protected override By PageHeader => By.CssSelector(".govuk-heading-l");
        private static By Applicant => By.CssSelector("a[data-label='application_review']");

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