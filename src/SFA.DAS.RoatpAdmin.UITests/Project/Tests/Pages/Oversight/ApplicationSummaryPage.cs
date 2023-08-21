using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class ApplicationSummaryPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Application summary";

        private static By ApproveGatewayOutcome => By.CssSelector("label[for='ApproveGateway']");
        private static By OverturnGatewayOutcome => By.CssSelector("label[for='OptionApproveGatewayNo']");
        private static By ApproveModertionOutcome => By.CssSelector("label[for='ApproveModeration']");
        private static By OverturnModerationOutcome => By.CssSelector("label[for='OptionApproveModerationNo']");
        private static By OversightSuccessful => By.CssSelector("label[for='OversightStatus']");
        private static By OversightSuccessfulAlreadyActive => By.CssSelector("label[for='OversightStatus']");
        private static By OversightSuccessfullFitnessForFunding => By.CssSelector("label[for='OptionSuccessfulFitnessForFunding']");
        private static By OversightUnSuccessful => By.CssSelector("label[for='OptionUnsuccessful']");
        private static By OversightInProgress => By.CssSelector("label[for='OptionInProgress']");
        private static By SuccessfulText => By.Id("SuccessfulText");
        private static By SuccessfulAlreadyActiveText => By.Id("SuccessfulAlreadyActiveText");
        private static By SuccessfullFitnessForFundingText => By.Id("SuccessfulFitnessForFundingText");
        private static By UnSuccessfulInternalText => By.Id("UnsuccessfulText");
        private static By UnSuccessfulExternalText => By.Id("UnsuccessfulExternalText");
        private static By InProgressInternalText => By.Id("InProgressInternalText");
        private static By InProgressExternalText => By.Id("InProgressExternalText");
        private static By AppealOversightSuccessfulAlreadyActive => By.CssSelector("label[for= 'AppealStatus']");
        private static By AppealOversightSuccessfulAlreadyActiveTextBox => By.Id("SuccessfulAlreadyActiveText");
        private static By AppealOversightSuccessful => By.CssSelector("label[for= 'AppealStatus']");

        protected override By ContinueButton => By.CssSelector(".govuk-button");

        public ApplicationSummaryPage(ScenarioContext context) : base(context) { }

        public AreYouSureSuccessfullPage MakeApplicationSuccessful()
        {
            formCompletionHelper.ClickElement(ApproveGatewayOutcome);
            formCompletionHelper.ClickElement(ApproveModertionOutcome);
            formCompletionHelper.ClickElement(OversightSuccessful);
            formCompletionHelper.EnterText(SuccessfulText, "Optional Successful Internal comments ");
            Continue();
            return new AreYouSureSuccessfullPage(context);
        }

        public AreYouSureSuccessfullPage MakeApplicationSuccessfulAlreadyActive()
        {
            formCompletionHelper.ClickElement(ApproveGatewayOutcome);
            formCompletionHelper.ClickElement(ApproveModertionOutcome);
            formCompletionHelper.ClickElement(OversightSuccessfulAlreadyActive);
            formCompletionHelper.EnterText(SuccessfulAlreadyActiveText, "Optional Successful Already Active Internal comments ");
            Continue();
            return new AreYouSureSuccessfullPage(context);
        }

        public AreYouSureSuccessfullPage MakeApplicationSuccessfulFitnessForFunding()
        {
            formCompletionHelper.ClickElement(ApproveGatewayOutcome);
            formCompletionHelper.ClickElement(ApproveModertionOutcome);
            formCompletionHelper.ClickElement(OversightSuccessfullFitnessForFunding);
            formCompletionHelper.EnterText(SuccessfullFitnessForFundingText, "Optional Successful Fitness For Funding Internal comments ");
            Continue();
            return new AreYouSureSuccessfullPage(context);
        }

        public OversightAssessmentCompletePage SendOutcomeToTheApplicant(string expectedStatus)
        {
            formCompletionHelper.ClickButtonByText(ContinueButton, "Send outcome");
            return new OversightAssessmentCompletePage(context, expectedStatus);
        }

        public ApplicationSummaryPage OverTurnThisApplication()
        {
            formCompletionHelper.ClickElement(OverturnGatewayOutcome);
            formCompletionHelper.ClickElement(OverturnModerationOutcome);
            return new ApplicationSummaryPage(context);
        }
        public ApplicationSummaryPage ApproveGatewayAndModerationOutcomes()
        {
            formCompletionHelper.ClickElement(ApproveGatewayOutcome);
            formCompletionHelper.ClickElement(ApproveModertionOutcome);
            return new ApplicationSummaryPage(context);
        }

        public AreYouSureUnSuccessfullPage MakeApplicationUnSuccessful()
        {
            formCompletionHelper.ClickElement(OversightUnSuccessful);
            formCompletionHelper.EnterText(UnSuccessfulInternalText, "UnSuccessful Internal comments ");
            formCompletionHelper.EnterText(UnSuccessfulExternalText, "UnSuccessful External comments ");
            Continue();
            return new AreYouSureUnSuccessfullPage(context);
        }
        public AreYouSureUnSuccessfullPage MakeApplicationUnSuccessful_ApprovedGatewayModerationOutcomes_Unsuccessful()
        {
            formCompletionHelper.ClickElement(OversightUnSuccessful);
            formCompletionHelper.EnterText(UnSuccessfulInternalText, "UnSuccessful Internal comments for approving Gateway and Moderation outcome");
            Continue();
            return new AreYouSureUnSuccessfullPage(context);
        }
        public AreYouSureInProgressPage MakeApplicationInProgress()
        {
            formCompletionHelper.ClickElement(OversightInProgress);
            formCompletionHelper.EnterText(InProgressInternalText, "In Progress Internal comments ");
            formCompletionHelper.EnterText(InProgressExternalText, "In Progress External comments ");
            Continue();
            return new AreYouSureInProgressPage(context);
        }
        public AreYouSureSuccessfullForAppealPage MakeApplicationSuccessful_Appeal()
        {
            formCompletionHelper.ClickElement(AppealOversightSuccessful);
            formCompletionHelper.EnterText(SuccessfulText, "Optional Successful Internal comments for Appeal");
            Continue();
            return new AreYouSureSuccessfullForAppealPage(context);
        }
        public AreYouSureSuccessfullForAppealPage MakeApplicationSuccessfulAlreadyActive_Appeal()
        {
            formCompletionHelper.ClickElement(AppealOversightSuccessfulAlreadyActive);
            formCompletionHelper.EnterText(AppealOversightSuccessfulAlreadyActiveTextBox, "Optional Successful Already Active Internal comments for Appeal ");
            Continue();
            return new AreYouSureSuccessfullForAppealPage(context);
        }

        public AreYouSureSuccessfullForAppealPage MakeApplicationSuccessfulFitnessForFunding_Appeal()
        {
            formCompletionHelper.ClickElement(OversightSuccessfullFitnessForFunding);
            formCompletionHelper.EnterText(SuccessfullFitnessForFundingText, "Optional Successful Fitness For Funding Internal comments for Appeal ");
            Continue();
            return new AreYouSureSuccessfullForAppealPage(context);
        }
        public AreYouSureUnSuccessfullForAppealPage MakeApplicationUnSuccessful_Appeal()
        {
            formCompletionHelper.ClickElement(OversightUnSuccessful);
            formCompletionHelper.EnterText(UnSuccessfulInternalText, "UnSuccessful Internal comments ");
            formCompletionHelper.EnterText(UnSuccessfulExternalText, "UnSuccessful External comments ");
            Continue();
            return new AreYouSureUnSuccessfullForAppealPage(context);
        }
        public AreYouSureInProgressForAppealPage MakeApplicationInProgress_Appeal()
        {
            formCompletionHelper.ClickElement(OversightInProgress);
            formCompletionHelper.EnterText(InProgressInternalText, "In Progress Internal comments ");
            formCompletionHelper.EnterText(InProgressExternalText, "In Progress External comments ");
            Continue();
            return new AreYouSureInProgressForAppealPage(context);
        }
    }
}
