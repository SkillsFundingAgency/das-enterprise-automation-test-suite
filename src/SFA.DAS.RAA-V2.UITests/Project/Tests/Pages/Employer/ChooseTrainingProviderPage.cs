using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
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
            VerifyPage();
        }

        public ConfirmTrainingProviderPage ChooseTrainingProvider()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "found_yes");
            _formCompletionHelper.EnterText(TrainingProviderSearch, "BALTIC TRAINING SERVICES LIMITED 10019026");
            _formCompletionHelper.SendKeys(TrainingProviderSearch, Keys.ArrowDown);
            _formCompletionHelper.SendKeys(TrainingProviderSearch, Keys.Enter);
            _formCompletionHelper.Click(Continue);
            return new ConfirmTrainingProviderPage(_context);
            
        }
    }
}
