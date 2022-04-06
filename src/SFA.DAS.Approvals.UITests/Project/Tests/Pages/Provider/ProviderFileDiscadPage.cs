using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderFileDiscadPage : ApprovalsBasePage
    {
        protected override By ContinueButton => By.Id("saveBtn");

        protected By ConfirmTrueRadioButton => By.Id("confirm-true");
        protected By ConfirmFalseRadioButton => By.Id("confirm-false");

        protected override string PageTitle => "Are you sure you want to discard this file?";

        public ProviderFileDiscadPage(ScenarioContext context) : base(context) { }

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
