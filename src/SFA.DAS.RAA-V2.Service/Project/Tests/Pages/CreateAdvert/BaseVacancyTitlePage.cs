using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public abstract class BaseVacancyTitlePage : RAAV2CSSBasePage
    {
        private By Title => By.CssSelector("#Title");

        public BaseVacancyTitlePage(ScenarioContext context) : base(context) { }

        public SelectOrganisationPage EnterAdvertTitleMultiOrg()
        {
            ChangeVacancyTitle();
            return new SelectOrganisationPage(context);
        }

        public ApprenticeshipTrainingPage EnterVacancyTitle()
        {
            ChangeVacancyTitle();
            return new ApprenticeshipTrainingPage(context);
        }

        public HaveYouAlreadyFoundTrainingPage EnterVacancyTitleForTheFirstVacancy()
        {
            ChangeVacancyTitle();
            return new HaveYouAlreadyFoundTrainingPage(context);
        }

        public VacancyPreviewPart2Page UpdateVacancyTitle()
        {
            ChangeVacancyTitle();
            return new VacancyPreviewPart2Page(context);
        }

        public CreateAnApprenticeshipAdvertPage UpdateVacancyTitleAndGoToCreateAnApprenticeshipAdvertPage()
        {
            ChangeVacancyTitle();
            return new CreateAnApprenticeshipAdvertPage(context);
        }

        private void ChangeVacancyTitle()
        {
            formCompletionHelper.EnterText(Title, $"{rAAV2DataHelper.VacancyTitle}");
            Continue();
            objectContext.SetVacancyTitle(rAAV2DataHelper.VacancyTitle);
        }
    }
}
