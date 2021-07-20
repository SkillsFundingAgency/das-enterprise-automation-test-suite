using OpenQA.Selenium;
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
        private By OversightSuccessful => By.CssSelector("label[for='OversightStatus']");
        private By OversightSuccessfulAlreadyActive => By.CssSelector("label[for='OptionSuccessfulAlreadyActive']");
        private By OversightSuccessfullFitnessForFunding => By.CssSelector("label[for='OptionSuccessfulFitnessForFunding']");
        private By OversightUnSuccessful => By.CssSelector("label[for='OptionUnsuccessful']");
        private By OversightInProgress => By.CssSelector("label[for='OptionInProgress']");
        private By SuccessfulText => By.Id("SuccessfulText");
        private By SuccessfulAlreadyActiveText => By.Id("SuccessfulAlreadyActiveText");
        private By SuccessfullFitnessForFundingText => By.Id("SuccessfulFitnessForFundingText");
        private By UnSuccessfulInternalText => By.Id("UnsuccessfulText");
        private By UnSuccessfulExternalText => By.Id("UnsuccessfulExternalText");
        private By InProgressInternalText => By.Id("InProgressInternalText");
        private By InProgressExternalText => By.Id("InProgressExternalText");

        protected override By ContinueButton => By.CssSelector(".govuk-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApplicationSummaryPage(ScenarioContext context) : base(context) => _context = context;

        public AreYouSureSuccessfullPage MakeApplicationSuccessful()
        {
            formCompletionHelper.ClickElement(ApproveGatewayOutcome);
            formCompletionHelper.ClickElement(ApproveModertionOutcome);
            formCompletionHelper.ClickElement(OversightSuccessful);
            formCompletionHelper.EnterText(SuccessfulText, "Optional Successful Internal comments ");
            Continue();
            return new AreYouSureSuccessfullPage(_context);
        }

        public AreYouSureSuccessfullPage MakeApplicationSuccessfulAlreadyActive()
        {
            formCompletionHelper.ClickElement(ApproveGatewayOutcome);
            formCompletionHelper.ClickElement(ApproveModertionOutcome);
            formCompletionHelper.ClickElement(OversightSuccessfulAlreadyActive);
            formCompletionHelper.EnterText(SuccessfulAlreadyActiveText, "Optional Successful Already Active Internal comments ");
            Continue();
            return new AreYouSureSuccessfullPage(_context);
        }

        public AreYouSureSuccessfullPage MakeApplicationSuccessfulFitnessForFunding()
        {
            formCompletionHelper.ClickElement(ApproveGatewayOutcome);
            formCompletionHelper.ClickElement(ApproveModertionOutcome);
            formCompletionHelper.ClickElement(OversightSuccessfullFitnessForFunding);
            formCompletionHelper.EnterText(SuccessfullFitnessForFundingText, "Optional Successful Fitness For Funding Internal comments ");
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
        public ApplicationSummaryPage ApproveGatewayAndModerationOutcomes()
        {
            formCompletionHelper.ClickElement(ApproveGatewayOutcome);
            formCompletionHelper.ClickElement(ApproveModertionOutcome);
            return new ApplicationSummaryPage(_context);
        }

        public AreYouSureUnSuccessfullPage MakeApplicationUnSuccessful()
        {
            formCompletionHelper.ClickElement(OversightUnSuccessful);
            formCompletionHelper.EnterText(UnSuccessfulInternalText, "UnSuccessful Internal comments ");
            formCompletionHelper.EnterText(UnSuccessfulExternalText, "UnSuccessful External comments ");
            Continue();
            return new AreYouSureUnSuccessfullPage(_context);
        }
        public AreYouSureUnSuccessfullPage MakeApplicationUnSuccessful_ApprovedGatewayModerationOutcomes_Unsuccessful()
        {
            formCompletionHelper.ClickElement(OversightUnSuccessful);
            formCompletionHelper.EnterText(UnSuccessfulInternalText, "UnSuccessful Internal comments for approving Gateway and Moderation outcome");
            Continue();
            return new AreYouSureUnSuccessfullPage(_context);
        }

        public AreYouSureInProgressPage MakeApplicationInProgress()
        {
            formCompletionHelper.ClickElement(OversightInProgress);
            formCompletionHelper.EnterText(InProgressInternalText, "In Progress Internal comments ");
            formCompletionHelper.EnterText(InProgressExternalText, "In Progress External comments ");
            Continue();
            return new AreYouSureInProgressPage(_context);
        }

        public AppealThisMessagePage ClickAppealThisApplication()
        {
            formCompletionHelper.ClickLinkByText("Appeal this application");
            return new AppealThisMessagePage(_context);
        }
    }
}
