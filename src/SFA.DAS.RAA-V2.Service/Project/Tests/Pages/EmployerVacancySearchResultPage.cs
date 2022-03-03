using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EmployerVacancySearchResultPage : VacancySearchResultPage
    {
        protected override string PageTitle => "Your adverts";

        protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        public EmployerVacancySearchResultPage(ScenarioContext context) : base(context) { }

        public ApprenticeshipTrainingPage GoToApprenticeshipTrainingPage()
        {
            DraftVacancy();
            return new ApprenticeshipTrainingPage(context);
        }

        public VacancyPreviewPart2Page GoToVacancyPreviewPart2Page()
        {
            DraftVacancy();
            return new VacancyPreviewPart2Page(context);
        }
    }
}