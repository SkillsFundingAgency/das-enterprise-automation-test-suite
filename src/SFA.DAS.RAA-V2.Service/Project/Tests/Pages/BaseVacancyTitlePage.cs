using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class BaseVacancyTitlePage : RAAV2CSSBasePage
    {
        private By Title => By.CssSelector("#Title");

        public BaseVacancyTitlePage(ScenarioContext context) : base(context) { }

        public ApprenticeshipTrainingPage EnterVacancyTitle()
        {
            ChangeVacancyTitle();
            return new ApprenticeshipTrainingPage(_context);
        }

        public HaveYouAlreadyFoundTrainingPage EnterVacancyTitleForTheFirstVacancy()
        {
            ChangeVacancyTitle();
            return new HaveYouAlreadyFoundTrainingPage(_context);
        }

        public VacancyPreviewPart2Page UpdateVacancyTitle()
        {
            ChangeVacancyTitle();
            return new VacancyPreviewPart2Page(_context);
        }

        private void ChangeVacancyTitle()
        {
            formCompletionHelper.EnterText(Title, $"{rAAV2DataHelper.VacancyTitle}");
            Continue();
            objectContext.SetVacancyTitle(rAAV2DataHelper.VacancyTitle);
        }
    }
}
