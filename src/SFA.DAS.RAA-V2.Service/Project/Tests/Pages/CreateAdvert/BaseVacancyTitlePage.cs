using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public abstract class BaseVacancyTitlePage(ScenarioContext context) : Raav2BasePage(context)
    {
        private static By Title => By.CssSelector("#Title");

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

        public TraineeshipSectorPage EnterTraineeshipVacancyTitle()
        {
            ChangeVacancyTitle();
            return new TraineeshipSectorPage(context);
        }

        public HaveYouAlreadyFoundTrainingPage EnterVacancyTitleForTheFirstAdvert()
        {
            ChangeVacancyTitle();
            return new HaveYouAlreadyFoundTrainingPage(context);
        }

        public CheckYourAnswersPage UpdateVacancyTitleAndGoToCheckYourAnswersPage()
        {
            ChangeVacancyTitle();
            return new CheckYourAnswersPage(context);
        }

        private void ChangeVacancyTitle()
        {
            var title = IsTraineeship ? rAAV2DataHelper.TraineeshipVacancyTitle : rAAV2DataHelper.VacancyTitle;
            formCompletionHelper.EnterText(Title, title);
            Continue();
            objectContext.SetVacancyTitle(title);
        }
    }
}
