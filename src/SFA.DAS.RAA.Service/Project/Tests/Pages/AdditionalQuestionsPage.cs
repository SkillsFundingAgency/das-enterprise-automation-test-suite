using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
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

        public CheckYourAnswersPage UpdateAllAdditionalQuestionsAndGoToCheckYourAnswersPage()
        {
            EnterAdditionalQuestions();

            Continue();

            return new CheckYourAnswersPage(context);
        }

        private void EnterAdditionalQuestions()
        {
            formCompletionHelper.EnterText(AdditionalQuestion1Selector, advertDataHelper.AdditionalQuestion1);
            formCompletionHelper.EnterText(AdditionalQuestion2Selector, advertDataHelper.AdditionalQuestion2);
        }
    }
}
