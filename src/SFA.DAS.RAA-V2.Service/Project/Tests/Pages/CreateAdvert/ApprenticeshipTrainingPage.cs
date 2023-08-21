using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class ApprenticeshipTrainingPage : Raav2BasePage
    {
        protected override string PageTitle => "What training course will the apprentice take?";

        private static By ProgrammeId => By.CssSelector("#SelectedProgrammeId");

        protected override By ContinueButton => By.CssSelector(".govuk-button.save-button");

        public ApprenticeshipTrainingPage(ScenarioContext context) : base(context) { }

        public ConfirmApprenticeshipTrainingPage EnterTrainingTitle()
        {
            EnterTrainingTitleAction();

            return new ConfirmApprenticeshipTrainingPage(context, EnterTrainingTitleAction);
        }

        private void EnterTrainingTitleAction()
        {
            formCompletionHelper.EnterText(ProgrammeId, rAAV2DataHelper.TrainingTitle);

            formCompletionHelper.Click(PageHeader);

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ContinueButton));
        }
    }
}
