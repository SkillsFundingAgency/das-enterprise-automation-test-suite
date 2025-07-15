using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert
{
    public class ApprenticeshipTrainingPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "What training course will the apprentice take?";

        private static By ProgrammeId => By.CssSelector("#SelectedProgrammeId");

        protected override By ContinueButton => By.CssSelector(".govuk-button.save-button");

        public ConfirmApprenticeshipTrainingPage EnterTrainingTitle()
        {
            var trainingTitle = IsFoundationAdvert ? RAADataHelper.FoundationTrainingTitle : RAADataHelper.TrainingTitle;
            EnterTrainingTitleAction(trainingTitle);

            return new ConfirmApprenticeshipTrainingPage(context, () => EnterTrainingTitleAction(trainingTitle));
        }

        private void EnterTrainingTitleAction(string trainingTitle)
        {
            formCompletionHelper.EnterText(ProgrammeId, trainingTitle);
            formCompletionHelper.Click(PageHeader);
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ContinueButton));
        }
    }
}
