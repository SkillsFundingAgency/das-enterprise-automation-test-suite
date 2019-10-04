using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManageFunding.UITests.Project.Tests.Pages.Employer
{
    public class DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage : BasePage
    {
        protected override string PageTitle => "Do you know which apprenticeship training your apprentice will take?";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ManageFundingConfig _config;
        #endregion

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetManageFundingConfig<ManageFundingConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        private By YesRadioButton => By.CssSelector("label[for=ApprenticeTrainingKnown]");

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickYesRadioButton()
        {
            _formCompletionHelper.ClickElement(YesRadioButton);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }

        private By TrainingCourseContainer => By.Id("SelectedCourseId");

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage EnterSelectForACourseAndSubmit()
        {
            _formCompletionHelper.EnterText(TrainingCourseContainer,"Food");
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }

        private By SaveAndContinueButton => By.CssSelector(".govuk-button");

        public WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage ClickSaveAndContinueButton()
        {
            _formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage(_context);
        }
    }
}
