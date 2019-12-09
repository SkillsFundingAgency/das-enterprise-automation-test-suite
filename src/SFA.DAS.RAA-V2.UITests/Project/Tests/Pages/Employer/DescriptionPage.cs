using OpenQA.Selenium;
using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class DescriptionPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Description of the apprenticeship";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly EmployerDataHelper _dataHelper;
        #endregion

        private By VacancyDescription => By.CssSelector("#tinymce[data-id='VacancyDescription'] > p");
        private By TrainingDescription => By.CssSelector("#tinymce[data-id='TrainingDescription'] > p");
        private By OutcomeDescription => By.CssSelector("#tinymce[data-id='OutcomeDescription'] > p");

        public DescriptionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<EmployerDataHelper>();
            VerifyPage();
        }

        public VacancyPreviewPart2Page EnterDescription()
        {
            _formCompletionHelper.EnterText(VacancyDescription, _dataHelper.VacancyShortDescription);
            _formCompletionHelper.EnterText(TrainingDescription, _dataHelper.TrainingDetails);
            _formCompletionHelper.EnterText(OutcomeDescription, _dataHelper.VacancyOutcome);
            _formCompletionHelper.Click(Continue);
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
