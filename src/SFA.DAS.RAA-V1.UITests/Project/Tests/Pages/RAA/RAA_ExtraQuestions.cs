using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ExtraQuestions : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Extra questions you'd like to ask candidates (optional)";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By ClickPreviewVacacncy => By.Name("VacancyQuestions");
        private By FirstQuestion => By.Id("FirstQuestion");
        private By SecondQuestion => By.Id("SecondQuestion");

        public RAA_ExtraQuestions(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public RAA_ExtraQuestions EnterFirstQuestion()
        {
            formCompletionHelper.EnterText(FirstQuestion, dataHelper.FirstQuestion);
            return this;
        }

        public RAA_ExtraQuestions EnterSecondQuestion()
        {
            formCompletionHelper.EnterText(SecondQuestion, dataHelper.SecondQuestion);
            return this;
        }

        public void ClickPreviewVacancyButton()
        {
            if (_pageInteractionHelper.IsElementDisplayed(ClickPreviewVacacncy))
            {
                formCompletionHelper.Click(ClickPreviewVacacncy);
            }
        }
    }
}
