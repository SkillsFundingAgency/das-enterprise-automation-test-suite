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
        private By OverturnGatewayOutcome => By.Id("ApproveGatewayOutcome");
        private By ApproveModertionOutcome => By.CssSelector("label[for='ApproveModeration']");
        private By OverturnModerationOutcome => By.Id("OptionApproveModerationNo");
        private By OversightSuccessfull => By.CssSelector("label[for='OversightStatus']");
        private By OversightSuccessfullAlreadyActive => By.Id("OptionSuccessfulAlreadyActive");
        private By OversightSuccessfullFitnessForFunding => By.Id("OptionSuccessfulFitnessForFunding");
        private By OversightUnSuccessfull => By.Id("OptionUnsuccessful");
        private By OversightInProgress => By.Id("OptionInProgress");
        private By SuccessfullText => By.Id("SuccessfulText");
        private By SuccessfullAlreadyActiveText => By.Id("SuccessfulAlreadyActiveText");
        private By SuccessfullFitnessForFundingText => By.Id("SuccessfulFitnessForFundingText");
        private By UnSuccessfullInternalText => By.Id("UnsuccessfulText");
        private By UnSuccessfullExternalText => By.Id("UnsuccessfulExternalText");
        private By InProgressInternalText => By.Id("InProgressInternalText");
        private By InProgressExternalText => By.Id("InProgressExternalText");

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

    }
}
