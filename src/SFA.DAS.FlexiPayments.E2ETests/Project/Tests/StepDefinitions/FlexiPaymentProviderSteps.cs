using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Transfers.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using static SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider.ProviderManageYourApprenticesPage;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FlexiPaymentProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TransfersProviderStepsHelper _providerStepsHelper;
        private ProviderApproveApprenticeDetailsPage _providerApproveApprenticeDetailsPage;
        private List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentices;

        public FlexiPaymentProviderSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _providerStepsHelper = new TransfersProviderStepsHelper(context);
        }


        [Given(@"provider logs in to review the cohort")]
        public void GivenProviderLogsInToReviewTheCohort() => _providerApproveApprenticeDetailsPage = _providerStepsHelper.CurrentCohortDetails();

        [When(@"the Provider approves the cohort")]
        public void WhenProviderApprovesTheCohort() => _providerStepsHelper.Approve();

        [Given(@"the provider adds Ulns and opts the learners out of the pilot")]
        [When(@"the provider adds Ulns and opts the learners out of the pilot")]
        public void WhenTheProviderAddsUlnsAndOptsTheLearnersOutOfThePilot() => _providerApproveApprenticeDetailsPage = _providerStepsHelper.ApproveFlexiPilotCohort(false);

        [When(@"Provider successfully approves the cohort")]
        [Then(@"Provider successfully approves the cohort")]
        public void ThenProviderApprovesTheCohort() => _providerApproveApprenticeDetailsPage.SubmitApprove();

        [Given(@"the provider adds Ulns and Opt the learners into the pilot")]
        [When(@"the provider adds Ulns and Opt the learners into the pilot")]
        public void ThenTheProviderAddsUlnsAndOptTheLearnersIntoThePilot() => _providerApproveApprenticeDetailsPage = _providerStepsHelper.ApproveFlexiPilotCohort(true);

        [Given(@"the provider adds Uln and Opt learner (.*) into the pilot")]
        public void GivenTheProviderAddsUlnAndOptLearnerIntoThePilot(int learnerNumber) => _providerStepsHelper.EditSpecificFlexiPaymentsPilotApprentice(_providerApproveApprenticeDetailsPage, learnerNumber, true);

        [Given(@"the provider adds Uln and Opt learner (.*) out of the pilot")]
        public void GivenTheProviderAddsUlnAndOptLearnerOutOfThePilot(int learnerNumber) => _providerStepsHelper.EditSpecificFlexiPaymentsPilotApprentice(_providerApproveApprenticeDetailsPage, learnerNumber, false);

        [When(@"pilot provider approves the cohort")]
        public void WhenPilotProviderApprovesCohort() => new ProviderApproveApprenticeDetailsPage(_context).SubmitApprove();

        [Then(@"Provider can search learner (.*) using Simplified Payments Pilot filter set to (yes|no) on Manage your apprentices page")]
        public void ThenProviderCanSearchLearnerUsingSimplifiedPaymentsPilotFilterSetToYesOnManageYourApprenticesPage(int learnerNumber, string filter)
        {
            listOfApprentices = _context.GetListOfApprenticesConfig<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>();

            SetApprenticeDetailsInContext(listOfApprentices, learnerNumber);

            SimplifiedPaymentsPilot filterValue = filter == "yes" ? SimplifiedPaymentsPilot.True : filter == "no" ? SimplifiedPaymentsPilot.False : SimplifiedPaymentsPilot.All;

            Assert.IsTrue(_providerStepsHelper.FindLearnerBySimplifiedPaymentsPilotFilter(filterValue));
        }

        [Then(@"Provider (can|cannot) make changes to fully approved learner (.*)")]
        public void ThenProviderIsUnableToMakeAnyChangesToFullyApprovedLearner(string action, int learnerNumber)
        {
            SetApprenticeDetailsInContext(listOfApprentices, learnerNumber);

            if (action == "can")
                _providerStepsHelper.ValidateProviderCanEditApprovedApprentice();
            else
                _providerStepsHelper.ValidateProviderCannotEditApprovedApprentice();
        }

        private void SetApprenticeDetailsInContext(List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentice, int learnerNumber)
        {
            void ReplaceInContext((ApprenticeDataHelper, ApprenticeCourseDataHelper) apprentice)
            {
                _context.Replace(apprentice.Item1);
                _context.Replace(apprentice.Item2);
            }

            var currentApprentice = listOfApprentice[learnerNumber-1];

            ReplaceInContext(currentApprentice);
        }
    }
}
