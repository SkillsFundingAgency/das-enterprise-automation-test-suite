using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;
using System.Collections.Generic;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class AdditionalQuestionsPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Application questions on Find an apprenticeship";

        private readonly List<string> MandatoryQuestions = new()
        {
            "What are your skills and strengths?",
            "What interests you about this apprenticeship?"
        };

        private static By PageTextSelector => By.CssSelector(".govuk-grid-column-two-thirds");
        private static By AdditionalQuestion1Selector => By.Id("AdditionalQuestion1");
        private static By AdditionalQuestion2Selector => By.Id("AdditionalQuestion2");

        public CreateAnApprenticeshipAdvertOrVacancyPage CompleteAllAdditionalQuestionsForApplicants(bool enterQuestion1 = true, bool enterQuestion2 = true)
        {
            CheckMandatoryQuestions();

            EnterAdditionalQuestions(enterQuestion1, enterQuestion2);

            Continue();

            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }

        public CheckYourAnswersPage UpdateAllAdditionalQuestionsAndGoToCheckYourAnswersPage(bool enterQuestion1 = true, bool enterQuestion2 = true)
        {
            EnterAdditionalQuestions(enterQuestion1, enterQuestion2);

            Continue();

            return new CheckYourAnswersPage(context);
        }

        private void EnterAdditionalQuestions(bool enterQuestion1, bool enterQuestion2)
        {
            if (enterQuestion1)
            {
                formCompletionHelper.EnterText(AdditionalQuestion1Selector, advertDataHelper.AdditionalQuestion1);
            }

            if (enterQuestion2)
            {
                formCompletionHelper.EnterText(AdditionalQuestion2Selector, advertDataHelper.AdditionalQuestion2);
            }
        }

        private void CheckMandatoryQuestions()
        {
            var pageText = pageInteractionHelper.GetText(PageTextSelector);
            foreach (var question in MandatoryQuestions)
            {
                pageInteractionHelper.VerifyText(pageText, question);
            }
        }
    }
}