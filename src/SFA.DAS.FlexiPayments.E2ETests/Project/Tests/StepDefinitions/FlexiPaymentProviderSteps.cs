using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
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

        [Then(@"Provider can search (first|second) learner using Simplified Payments Pilot filter set to (yes|no) on Manage your apprentices page")]
        public void ThenProviderCanSearchLearnerUsingSimplifiedPaymentsPilotFilterOnManageYourApprenticesPage(string learner, string filter)
        {
            string apprenticeFullName;
            SimplifiedPaymentsPilot filterValue; 

            var listOfApprentice = _context.GetListOfApprenticesConfig<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>();

            if (learner == "first")
                apprenticeFullName = listOfApprentice.First().Item1.ApprenticeFullName;
            else
            {
                listOfApprentice.Remove(listOfApprentice.First());
                apprenticeFullName = listOfApprentice.First().Item1.ApprenticeFullName;
            }

            filterValue = filter == "yes" ? SimplifiedPaymentsPilot.True : filter == "no" ? SimplifiedPaymentsPilot.False : SimplifiedPaymentsPilot.All;

            Assert.IsTrue(_providerStepsHelper.FindLearnerBySimplifiedPaymentsPilotFilter(apprenticeFullName, filterValue)); 
        }

        [Then(@"Provider can search learner (.*) using Simplified Payments Pilot filter set to (yes|no) on Manage your apprentices page")]
        public void ThenProviderCanSearchLearnerUsingSimplifiedPaymentsPilotFilterSetToYesOnManageYourApprenticesPage(int learnerNumber, string filter)
        {
            var listOfApprentice = _context.GetListOfApprenticesConfig<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>();

            string apprenticeFullName = listOfApprentice[learnerNumber-1].Item1.ApprenticeFullName;

            SimplifiedPaymentsPilot filterValue = filter == "yes" ? SimplifiedPaymentsPilot.True : filter == "no" ? SimplifiedPaymentsPilot.False : SimplifiedPaymentsPilot.All;

            Assert.IsTrue(_providerStepsHelper.FindLearnerBySimplifiedPaymentsPilotFilter(apprenticeFullName, filterValue));
        }

    }
}
