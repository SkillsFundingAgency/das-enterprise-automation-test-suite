using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class DescriptionPage : Raav2BasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "Tasks and training details" : "Tasks and training details";

        private By IframeBody => By.CssSelector(".mce-content-body ");
        private By OutcomeDescription => By.Id("OutcomeDescription_ifr");
        private By TrainingDescription => By.Id("TrainingDescription_ifr");
        private By VacancyDescription => By.Id("VacancyDescription_ifr");

        public DescriptionPage(ScenarioContext context) : base(context) { }

        public PreviewYourAdvertOrVacancyPage EnterDescription()
        {
            javaScriptHelper.SwitchFrameAndEnterText(VacancyDescription, IframeBody, rAAV2DataHelper.VacancyShortDescription);
            javaScriptHelper.SwitchFrameAndEnterText(TrainingDescription, IframeBody, rAAV2DataHelper.TrainingDetails);
            javaScriptHelper.SwitchFrameAndEnterText(OutcomeDescription, IframeBody, rAAV2DataHelper.VacancyOutcome);
            Continue();
            return new PreviewYourAdvertOrVacancyPage(context);
        }

        public CreateAnApprenticeshipAdvertOrVacancyPage EnterTasksAndTrainingDetails()
        {
            EnterVacancyAndTrainingDetails();
            Continue();
            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }


        public CreateAnApprenticeshipAdvertOrVacancyPage EnterAllDescription()
        {
            EnterVacancyAndTrainingDetails();
            Continue();
            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }

        private void EnterVacancyAndTrainingDetails()
        {
            javaScriptHelper.SwitchFrameAndEnterText(VacancyDescription, IframeBody, rAAV2DataHelper.VacancyShortDescription);
            javaScriptHelper.SwitchFrameAndEnterText(TrainingDescription, IframeBody, rAAV2DataHelper.TrainingDetails);
        }
    }
}
