using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmApprenticeshipTrainingPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Confirm apprenticeship training";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("[data-automation='btn-continue']");

        public ConfirmApprenticeshipTrainingPage(ScenarioContext context, Action retryAction) : base(context, false)
        {
            _context = context;

            VerifyPage(retryAction);
        }

        public ChooseTrainingProviderPage ConfirmTrainingAndContinue()
        {
            Continue();
            return new ChooseTrainingProviderPage(_context);
        }

        public SubmitNoOfPositionsPage ConfirmAndNavigateToNoOfPositionsPage()
        {
            Continue(); 
            return new SubmitNoOfPositionsPage(_context);
        }
    }
}
