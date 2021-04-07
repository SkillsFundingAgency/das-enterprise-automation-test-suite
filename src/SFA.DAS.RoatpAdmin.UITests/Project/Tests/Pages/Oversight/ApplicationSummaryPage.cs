using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class ApplicationSummaryPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Application summary";

        private By ApproveGatewayOutcome => By.CssSelector("label[for='ApproveGateway']");
        private By OverturnGatewayOutcome => By.CssSelector("label[for='OptionApproveGatewayNo']");
        private By ApproveModertionOutcome => By.CssSelector("label[for='ApproveModeration']");
        private By OverturnModerationOutcome => By.CssSelector("label[for='OptionApproveModerationNo']");
        private By OversightSuccessfull => By.CssSelector("label[for='OversightStatus']");
        private By OversightSuccessfullAlreadyActive => By.CssSelector("label[for='OptionSuccessfulAlreadyActive']");
        private By OversightSuccessfullFitnessForFunding => By.CssSelector("label[for='OptionSuccessfulFitnessForFunding']");
        private By OversightUnSuccessfull => By.CssSelector("label[for='OptionUnsuccessful']");
        private By OversightInProgress => By.CssSelector("label[for='OptionInProgress']");
        private By SuccessfullText => By.Id("SuccessfulText");
        private By SuccessfullAlreadyActiveText => By.Id("SuccessfulAlreadyActiveText");
        private By SuccessfullFitnessForFundingText => By.Id("SuccessfulFitnessForFundingText");
        private By UnSuccessfullInternalText => By.Id("UnsuccessfulText");
        private By UnSuccessfullExternalText => By.Id("UnsuccessfulExternalText");
        private By InProgressInternalText => By.Id("InProgressInternalText");
        private By InProgressExternalText => By.Id("InProgressExternalText");

        protected override By ContinueButton => By.CssSelector(".govuk-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApplicationSummaryPage(ScenarioContext context) : base(context) => _context = context;

        public AreYouSureSuccessfullPage ApproveOverallOutcome()
        {
            formCompletionHelper.ClickElement(ApproveGatewayOutcome);
            formCompletionHelper.ClickElement(ApproveModertionOutcome);
            formCompletionHelper.ClickElement(OversightSuccessfull);
            formCompletionHelper.EnterText(SuccessfullText, "Optional Successfull Internal comments ");
            Continue();
            return new AreYouSureSuccessfullPage(_context);
        }

        public OversightAssessmentCompletePage SendOutcomeToTheApplicant(string expectedStatus)
        {
            formCompletionHelper.ClickButtonByText(ContinueButton, "Send outcome");
            return new OversightAssessmentCompletePage(_context, expectedStatus);
        }

        public ApplicationSummaryPage OverTurnThisApplication()
        {
            formCompletionHelper.ClickElement(OverturnGatewayOutcome);
            formCompletionHelper.ClickElement(OverturnModerationOutcome);
            return new ApplicationSummaryPage(_context);
        }

        public AreYouSureUnSuccessfullPage MakeApplicationUnSuccessfull()
        {
            formCompletionHelper.ClickElement(OversightUnSuccessfull);
            formCompletionHelper.EnterText(UnSuccessfullInternalText, "UnSuccessfull Internal comments ");
            formCompletionHelper.EnterText(UnSuccessfullExternalText, "UnSuccessfull External comments ");
            Continue();
            return new AreYouSureUnSuccessfullPage(_context);
        }


    }
}
