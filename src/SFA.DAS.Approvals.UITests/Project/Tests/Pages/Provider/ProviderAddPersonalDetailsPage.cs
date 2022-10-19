using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddPersonalDetailsPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Personal details";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading, .govuk-heading-xl");
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");
        private static By Uln => By.Id("Uln");
        private static By AddButton => By.XPath("//button[text()='Add']");

        public ProviderAddPersonalDetailsPage(ScenarioContext context) : base(context)  { }

        internal ProviderAddTrainingDetailsPage SubmitValidApprenticePersonalDetails(bool isPilotLearner = false)
        {
            formCompletionHelper.EnterText(Uln, apprenticeDataHelper.Uln());

            EnterApprenticeMandatoryValidDetails();

            EnterDob();

            if (tags.Contains("flexi-payments")) AddFlexiPaymentsPilotSelection(isPilotLearner);

            formCompletionHelper.Click(ContinueButton);

            return new ProviderAddTrainingDetailsPage(context);
        }

        private void AddFlexiPaymentsPilotSelection(bool isPilotLearner)
        {
                if (isPilotLearner) SelectRadioOptionByForAttribute("IsOnFlexiPaymentPilot");
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