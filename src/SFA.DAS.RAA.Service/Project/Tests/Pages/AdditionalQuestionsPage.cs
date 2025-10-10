using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

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

        private readonly List<string> FoundationsMandatoryQuestions = new()
        {
            "What interests you about this apprenticeship?"
        };

        private static By PageTextSelector => By.CssSelector("main .govuk-grid-column-two-thirds");
        private static By AdditionalQuestion1Selector => By.Id("AdditionalQuestion1");
        private static By AdditionalQuestion2Selector => By.Id("AdditionalQuestion2");

        public CreateAnApprenticeshipAdvertOrVacancyPage CompleteAllAdditionalQuestionsForApplicants(bool isFoundationAdvert, bool enterQuestion1, bool enterQuestion2)
        {
            CheckMandatoryQuestions(isFoundationAdvert);

            EnterAdditionalQuestions(enterQuestion1, enterQuestion2);

            Continue();

            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }

        public CheckYourAnswersPage UpdateAllAdditionalQuestionsAndGoToCheckYourAnswersPage(bool enterQuestion1, bool enterQuestion2)
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

        private void CheckMandatoryQuestions(bool isFoundationAdvert)
        {
            var pageText = pageInteractionHelper.GetText(PageTextSelector);
            var questionsToCheck = isFoundationAdvert ? FoundationsMandatoryQuestions : MandatoryQuestions;
            foreach (var question in questionsToCheck)
            {
                pageInteractionHelper.VerifyText(pageText, question);
            }
        }
    }
}