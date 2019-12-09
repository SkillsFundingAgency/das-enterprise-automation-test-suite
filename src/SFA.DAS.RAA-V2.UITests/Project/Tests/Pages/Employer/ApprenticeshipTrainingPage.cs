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
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly EmployerDataHelper _dataHelper;
        #endregion

        private By ProgrammeId => By.CssSelector("#SelectedProgrammeId");

        public ApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<EmployerDataHelper>();
            VerifyPage();
        }


        public ConfirmApprenticeshipTrainingPage EnterTrainingTitle()
        {
            _formCompletionHelper.SendKeys(ProgrammeId, _dataHelper.TrainingTitle);
            _formCompletionHelper.SendKeys(ProgrammeId, Keys.ArrowDown);
            _formCompletionHelper.SendKeys(ProgrammeId, Keys.Enter);
            _formCompletionHelper.Click(Continue);
            return new ConfirmApprenticeshipTrainingPage(_context);
        }
    }
}
