using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmTrainingProviderPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Confirm the training provider";

        private  By ConfirmAndContinueButton => By.CssSelector("[data-automation='btn-continue']");
        #region Helpers and Context
        private readonly ScenarioContext _context;

        #endregion

        public ConfirmTrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public SubmitNoOfPositionsPage ConfirmTrainingProviderAndContinue()
        {
            formCompletionHelper.Click(ConfirmAndContinueButton);
            return new SubmitNoOfPositionsPage(_context);
        }
    }
}
