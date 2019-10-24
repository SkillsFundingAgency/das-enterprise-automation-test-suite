using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ExtraQuestions : BasePage
    {
        protected override string PageTitle => "Extra questions you'd like to ask candidates (optional)";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1DataHelper _dataHelper;
        #endregion

        private By ClickPreviewVacacncy => By.Name("VacancyQuestions");
        private By FirstQuestion => By.Id("FirstQuestion");
        private By SecondQuestion => By.Id("SecondQuestion");

        public RAA_ExtraQuestions(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<RAAV1DataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public RAA_ExtraQuestions EnterFirstQuestion()
        {
            _formCompletionHelper.EnterText(FirstQuestion, _dataHelper.FirstQuestion);
            return this;
        }

        public RAA_ExtraQuestions EnterSecondQuestion()
        {
            _formCompletionHelper.EnterText(SecondQuestion, _dataHelper.SecondQuestion);
            return this;
        }

        public void ClickPreviewVacancyButton()
        {
            if (_pageInteractionHelper.IsElementDisplayed(ClickPreviewVacacncy))
            {
                _formCompletionHelper.Click(ClickPreviewVacacncy);
            }
        }
    }
}
