using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EmployerVacancySearchResultPage : VacancySearchResultPage
    {
        protected override string PageTitle => "Your adverts";

        protected override By PageHeader => By.CssSelector(".govuk-heading-l");
        private By Applicant => By.CssSelector(".responsive a, .das-table--responsive a");

        public EmployerVacancySearchResultPage(ScenarioContext context) : base(context) { }

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
            formCompletionHelper.Click(Applicant);
            return new ManageApplicantPage(context);
        }
        public ViewVacancyPage NavigateToViewAdvertPage()
        {
            GoToVacancyManagePage();
            string linkTest = isRaaV2Employer ? "View advert" : "View vacancy";
            tabHelper.OpenInNewTab(() => formCompletionHelper.ClickLinkByText(linkTest));

            return new ViewVacancyPage(context);
        }
    }
}