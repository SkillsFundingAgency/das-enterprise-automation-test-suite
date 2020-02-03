using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmApprenticeshipTrainingPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Confirm apprenticeship training";

        #region Helpers and Context
        private readonly ScenarioContext _context;

        #endregion

        private By ConfirmAndContinue = By.CssSelector("[data-automation='btn-continue']");

        public ConfirmApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ChooseTrainingProviderPage ConfirmTrainingAndContinue()
        {
            formCompletionHelper.Click(ConfirmAndContinue);
            return new ChooseTrainingProviderPage(_context);
        }

        public SubmitNoOfPositionsPage ConfirmAndNavigateToNoOfPositionsPage()
        {
            formCompletionHelper.Click(ConfirmAndContinue); 
            return new SubmitNoOfPositionsPage(_context);
        }
    }
}
