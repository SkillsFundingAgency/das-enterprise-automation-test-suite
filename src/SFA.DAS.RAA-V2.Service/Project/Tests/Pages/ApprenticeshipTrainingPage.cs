using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
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

        private By CancelLink => By.LinkText("Cancel");

        protected override By ContinueButton => By.CssSelector(".govuk-button.save-button");

        public ApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public ConfirmApprenticeshipTrainingPage EnterTrainingTitle()
        {
            EnterTrainingTitleAction();

            return new ConfirmApprenticeshipTrainingPage(_context, EnterTrainingTitleAction);
        }

        private void EnterTrainingTitleAction()
        {
            formCompletionHelper.EnterText(ProgrammeId, rAAV2DataHelper.TrainingTitle);

            if (pageInteractionHelper.FindElements(FirstOption).Count > 0)
            {
                formCompletionHelper.ClickElement(() =>
                {
                    pageInteractionHelper.WaitForElementToBeClickable(FirstOption);
                    return pageInteractionHelper.FindElement(FirstOption);
                });
            }

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ContinueButton));
        }

        public YourAdvertsPage CancelVacancy()
        {
            formCompletionHelper.Click(CancelLink);
            return new YourAdvertsPage(_context);
        }
    }
}
