using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ChooseTrainingProviderPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Have you found a training provider?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By TrainingProviderSearch => By.CssSelector("#TrainingProviderSearch");

        public ChooseTrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ConfirmTrainingProviderPage ChooseTrainingProvider()
        {
            SelectRadioOptionByForAttribute("found_yes");
            formCompletionHelper.EnterText(TrainingProviderSearch, "BALTIC TRAINING SERVICES LIMITED 10019026");
            formCompletionHelper.SendKeys(TrainingProviderSearch, Keys.ArrowDown);
            formCompletionHelper.SendKeys(TrainingProviderSearch, Keys.Enter);
            Continue();
            return new ConfirmTrainingProviderPage(_context);
            
        }
    }
}
