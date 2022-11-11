using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V104.Network;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddPersonalDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        private readonly Boolean _isFlexiPaymentPilotProvider;
        protected override string PageTitle => "Add personal details";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading, .govuk-heading-xl");
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");
        private static By Uln => By.Id("Uln");

        public ProviderAddPersonalDetailsPage(ScenarioContext context) : base(context) 
        {
            _isFlexiPaymentPilotProvider = tags.Contains("flexi-payments");
        }

        internal ProviderAddTrainingDetailsPage SubmitValidPersonalDetails(bool isFlexiPaymentPilotLearner = false)
        {
            if (objectContext.HasUlnForOLTD()) formCompletionHelper.EnterText(Uln, objectContext.GetUlnForOLTD());
            else formCompletionHelper.EnterText(Uln, apprenticeDataHelper.Uln());

            EnterApprenticeMandatoryValidDetails();

            EnterDob();

            if (_isFlexiPaymentPilotProvider) AddFlexiPaymentsPilotSelection(isFlexiPaymentPilotLearner);

            formCompletionHelper.Click(ContinueButton);

            return new ProviderAddTrainingDetailsPage(context, isFlexiPaymentPilotLearner);
        }

        private void AddFlexiPaymentsPilotSelection(bool isFlexiPaymentPilotLearner)
        {
            if (isFlexiPaymentPilotLearner) SelectRadioOptionByForAttribute("IsOnFlexiPaymentPilot");
            else SelectRadioOptionByForAttribute("IsOnFlexiPaymentPilot-no");
        }

        private new void EnterApprenticeMandatoryValidDetails()
        {
            EnterApprenticeName();

            if (tags.Contains("aslistedemployer")) return;

            EnterApprenticeEmail();
        }
    }
}