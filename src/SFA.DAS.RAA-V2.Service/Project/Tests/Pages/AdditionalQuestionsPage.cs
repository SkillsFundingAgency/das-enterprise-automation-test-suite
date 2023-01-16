using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class AdditionalQuestionsPage : Raav2BasePage
    {
        protected override string PageTitle => "Do you have any questions you would like to ask applicants? (optional)";

        public AdditionalQuestionsPage(ScenarioContext context) : base(context) { }

        private By AdditionalQuestion1Selector => By.Id("AdditionalQuestion1");
        private By AdditionalQuestion2Selector => By.Id("AdditionalQuestion2");

        public CreateAnApprenticeshipAdvertOrVacancyPage CompleteAllAdditionalQuestionsForApplicants()
        {
            EnterAdditionalQuestions();
            Continue();

            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }

        private void EnterAdditionalQuestions()
        {
            formCompletionHelper.EnterText(AdditionalQuestion1Selector, rAAV2DataHelper.RandomAlphabeticString(60));
            formCompletionHelper.EnterText(AdditionalQuestion2Selector, rAAV2DataHelper.RandomAlphabeticString(60));
        }
    }
}
