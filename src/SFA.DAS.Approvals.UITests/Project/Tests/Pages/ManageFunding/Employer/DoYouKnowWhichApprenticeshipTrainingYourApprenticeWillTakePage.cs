using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage : BasePage
    {
        protected override string PageTitle => "Do you know which apprenticeship training your apprentice will take?";
        private By YesRadioButton => By.CssSelector("label[for=ApprenticeTrainingKnown]");
        private By TrainingCourseContainer => By.Id("SelectedCourseId");

        private By StandardCourseOption => By.Id("SelectedCourseId__option--0");
        private By SaveAndContinueButton => By.CssSelector(".govuk-button");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickYesRadioButton()
        {
            _formCompletionHelper.ClickElement(YesRadioButton);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage EnterSelectForACourseAndSubmit()
        {
            _formCompletionHelper.EnterText(TrainingCourseContainer, "Food Technologist - Level 3");
            _formCompletionHelper.ClickElement(StandardCourseOption);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }

        public WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage ClickSaveAndContinueButton()
        {
            _formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage(_context);
        }
    }
}
