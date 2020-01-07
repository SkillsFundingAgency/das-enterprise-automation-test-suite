using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
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

        private By CancelLink => By.CssSelector(".das-button-link");

        public ApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public ConfirmApprenticeshipTrainingPage EnterTrainingTitle()
        {
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(ProgrammeId, dataHelper.TrainingTitle); return _pageInteractionHelper.FindElement(FirstOption); });
            Continue();
            return new ConfirmApprenticeshipTrainingPage(_context);
        }
    }
}
