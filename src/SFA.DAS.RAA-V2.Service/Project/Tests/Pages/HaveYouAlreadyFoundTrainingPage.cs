using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class HaveYouAlreadyFoundTrainingPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Have you already found apprenticeship training?";

        #region Helpers And Context
        private readonly ScenarioContext _context;
        #endregion

        private By YesRadioButton => By.Id("has_training_yes");

        protected override By ContinueButton => By.CssSelector("[data-automation='btn-continue']");

        public HaveYouAlreadyFoundTrainingPage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeshipTrainingPage SelectYes()
        {
            formCompletionHelper.SelectRadioOptionByLocator(YesRadioButton);

            Continue();

            return new ApprenticeshipTrainingPage(_context);
        }
    }
}
