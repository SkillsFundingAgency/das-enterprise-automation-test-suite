using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class ApprenticeshipTrainingPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => "What training course will the apprentice take?";

        private static By ProgrammeId => By.CssSelector("#SelectedProgrammeId");

        protected override By ContinueButton => By.CssSelector(".govuk-button.save-button");

        public ConfirmApprenticeshipTrainingPage EnterTrainingTitle()
        {
            EnterTrainingTitleAction();

            return new ConfirmApprenticeshipTrainingPage(context, EnterTrainingTitleAction);
        }

        private void EnterTrainingTitleAction()
        {
            formCompletionHelper.EnterText(ProgrammeId, RAAV2DataHelper.TrainingTitle);

            formCompletionHelper.Click(PageHeader);

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ContinueButton));
        }
    }
}
