using OpenQA.Selenium;
using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeshipTrainingPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "What training will the apprentice take?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By ProgrammeId => By.CssSelector("#SelectedProgrammeId");

        private By FirstOption => By.CssSelector("#SelectedProgrammeId__option--0");

        public ApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public ConfirmApprenticeshipTrainingPage EnterTrainingTitle()
        {
            _formCompletionHelper.ClickElement(() => { _formCompletionHelper.SendKeys(ProgrammeId, _dataHelper.TrainingTitle); return _pageInteractionHelper.FindElement(FirstOption); });
            _formCompletionHelper.Click(Continue);
            return new ConfirmApprenticeshipTrainingPage(_context);
        }
    }
}
