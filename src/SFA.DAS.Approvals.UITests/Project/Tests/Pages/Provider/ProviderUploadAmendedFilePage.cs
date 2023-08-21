using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderUploadAmendedFilePage : ApprovalsBasePage
    {
        protected override By ContinueButton => By.Id("continueBtn");

        protected static By ConfirmTrueRadioButton => By.Id("confirm-true");
        protected static By ConfirmFalseRadioButton => By.Id("confirm-false");

        protected override string PageTitle => "Are you sure you want to upload an amended file?";

        public ProviderUploadAmendedFilePage(ScenarioContext context) : base(context) { }

        internal void SelectYesAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ConfirmTrueRadioButton);
            Continue();
        }

        internal void SelectNoAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ConfirmFalseRadioButton);
            Continue();
        }
    }
}
