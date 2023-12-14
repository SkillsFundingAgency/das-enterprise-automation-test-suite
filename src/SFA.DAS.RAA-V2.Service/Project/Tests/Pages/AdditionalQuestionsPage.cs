using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class AdditionalQuestionsPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => "Do you have any questions you would like to ask applicants? (optional)";

        private static By AdditionalQuestion1Selector => By.Id("AdditionalQuestion1");
        private static By AdditionalQuestion2Selector => By.Id("AdditionalQuestion2");

        public CreateAnApprenticeshipAdvertOrVacancyPage CompleteAllAdditionalQuestionsForApplicants()
        {
            EnterAdditionalQuestions();
            Continue();

            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }

        private void EnterAdditionalQuestions()
        {
            formCompletionHelper.EnterText(AdditionalQuestion1Selector, RAA.DataGenerator.RAAV2DataHelper.RandomQuestionString(20));
            formCompletionHelper.EnterText(AdditionalQuestion2Selector, RAA.DataGenerator.RAAV2DataHelper.RandomQuestionString(20));
        }
    }
}
