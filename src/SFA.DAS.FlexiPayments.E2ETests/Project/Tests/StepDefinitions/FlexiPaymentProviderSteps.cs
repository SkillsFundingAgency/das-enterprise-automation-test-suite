using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Transfers.UITests.Project.Helpers;
using TechTalk.SpecFlow;
using static SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider.ProviderManageYourApprenticesPage;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FlexiPaymentProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly TransfersProviderStepsHelper _providerStepsHelper;
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;
        private readonly ProviderEditStepsHelper _providerEditStepsHelper;
        private ProviderApproveApprenticeDetailsPage _providerApproveApprenticeDetailsPage;
        protected readonly ReplaceApprenticeDatahelper _replaceApprenticeDatahelper;
        private readonly ProviderApproveStepsHelper _providerApproveStepsHelper;

        public FlexiPaymentProviderSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new TransfersProviderStepsHelper(context);
            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);
            _providerEditStepsHelper = new ProviderEditStepsHelper(context);
            _replaceApprenticeDatahelper = new ReplaceApprenticeDatahelper(context);
            _providerApproveStepsHelper = new ProviderApproveStepsHelper(context);
        }

        [Given(@"provider logs in to review the cohort")]
        [When(@"provider logs in to review the cohort")]
        public void GivenProviderLogsInToReviewTheCohort() => _providerApproveApprenticeDetailsPage = _providerCommonStepsHelper.CurrentCohortDetails();

        [When(@"the Provider approves the cohort")]
        public void WhenProviderApprovesTheCohort() => _providerApproveStepsHelper.EditAndApprove();

        [Given(@"the provider adds Ulns and opts the learners out of the pilot")]
        [When(@"the provider adds Ulns and opts the learners out of the pilot")]
        public void WhenTheProviderAddsUlnsAndOptsTheLearnersOutOfThePilot() => _providerApproveApprenticeDetailsPage = _providerEditStepsHelper.EditFlexiPilotApprentice(false);

        [When(@"Provider successfully approves the cohort")]
        [Then(@"Provider successfully approves the cohort")]
        public void ThenProviderApprovesTheCohort() => _providerApproveApprenticeDetailsPage.SubmitApprove();

        [Given(@"the provider adds Ulns and Opt the learners into the pilot")]
        [When(@"the provider adds Ulns and Opt the learners into the pilot")]
        public void ThenTheProviderAddsUlnsAndOptTheLearnersIntoThePilot() => _providerApproveApprenticeDetailsPage = _providerEditStepsHelper.EditFlexiPilotApprentice(true);


        [Given(@"the provider adds Uln and Opt learner (.*) into the pilot")]
        public void ProviderAddsUlnAndOptLearnerIntoThePilot(int learnerNumber) => _providerEditStepsHelper.EditSpecificFlexiPaymentsPilotApprentice(_providerApproveApprenticeDetailsPage, learnerNumber, true);

        [Given(@"Simplified Payments Pilot tags and additional columns are displayed on Approve apprentice details page")]
        public void GivenSimplifiedPaymentsPilotTagsAndAdditionalColumnsAreDisplayedOnApproveApprenticeDetailsPage() => _providerApproveApprenticeDetailsPage.VerifySimplifiedPaymentsPilotTagAndColumns(true);

        [Given(@"Simplified Payments Pilot tags and additional columns are NOT displayed on Approve apprentice details page")]
        public void GivenSimplifiedPaymentsPilotTagsAndAdditionalColumnsAreNOTDisplayedOnApproveApprenticeDetailsPage() => _providerApproveApprenticeDetailsPage.VerifySimplifiedPaymentsPilotTagAndColumns(false);


        [Given(@"the provider adds Uln and Opt learner (.*) out of the pilot")]
        public void ProviderAddsUlnAndOptLearnerOutOfThePilot(int learnerNumber) => _providerEditStepsHelper.EditSpecificFlexiPaymentsPilotApprentice(_providerApproveApprenticeDetailsPage, learnerNumber, false);

        [Given(@"pilot provider approves the cohort")]
        [When(@"pilot provider approves the cohort")]
        public void WhenPilotProviderApprovesCohort() => new ProviderApproveApprenticeDetailsPage(_context).SubmitApprove();

        [When(@"Provider can search learner (.*) using Simplified Payments Pilot filter set to (yes|no) on Manage your apprentices page")]
        public void ProviderCanSearchLearnerUsingSimplifiedPaymentsPilotFilterSetToYesOnManageYourApprenticesPage(int learnerNumber, string filter)
        {
            SetApprenticeDetailsInContext(learnerNumber);

            SimplifiedPaymentsPilot filterValue = filter == "yes" ? SimplifiedPaymentsPilot.True : filter == "no" ? SimplifiedPaymentsPilot.False : SimplifiedPaymentsPilot.All;

            Assert.IsTrue(_providerCommonStepsHelper.GoToProviderHomePage().GoToProviderManageYourApprenticePage().IsPaymentsPilotLearnerDisplayed(filterValue));
        }

        [Then(@"Provider (can|cannot) make changes to fully approved learner (.*)")]
        public void ThenProviderIsUnableToMakeAnyChangesToFullyApprovedLearner(string action, int learnerNumber)
        {
            SetApprenticeDetailsInContext(learnerNumber);

            new ProviderManageYourApprenticesPage(_context).SelectViewCurrentApprenticeDetails().ValidateProviderEditApprovedApprentice(action == "can");
        }

        [Then(@"validate provider (can|cannot) view Pilot DataLock message")]
        public void ThenValidateProviderCanViewPilotDataLockMessage(string action)
        {
            _providerCommonStepsHelper.GoToProviderHomePage(false)
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ValidateFlexiPaymentDataLockMessageDisplayed(action == "can");
        }

        [Then(@"validate Training Price and EPA price have been reset with blue warning message displayed")]
        public void ThenValidateTrainingPriceAndEPAPriceHaveBeenResetWithBlueWarningMessageDisplayed() => _providerApproveApprenticeDetailsPage.ValidateTrainingPriceAndEPAValuesHaveBeenReset();

        [Then(@"verify training provider cannot approve the cohort")]
        public void ThenValidateCohortCannotBeApproved() => _providerApproveApprenticeDetailsPage.VerifyProviderCanNotApprove();

        internal void SetApprenticeDetailsInContext(int learnerNumber) => _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(learnerNumber - 1);
    }
}
