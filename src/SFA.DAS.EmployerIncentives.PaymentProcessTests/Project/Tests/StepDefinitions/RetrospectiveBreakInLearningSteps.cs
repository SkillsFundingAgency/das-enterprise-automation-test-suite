using System;
using System.Threading.Tasks;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "RetrospectiveBreakInLearning")]
    public class RetrospectiveBreakInLearningSteps : StepsBase
    {
        private DateTime _initialStartDate;
        private DateTime _initialEndDate;

        protected RetrospectiveBreakInLearningSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"an existing apprenticeship incentive with learning starting on (.*) and ending on (.*)")]
        public async Task GivenAnExistingApprenticeshipIncentiveWithLearningStartingIn_Oct(DateTime startDate, DateTime endDate)
        {
            _initialStartDate = startDate;
            _initialEndDate = endDate;
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(6, 2021);

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN,
                    startDate, startDate.AddYears(-20), Phase.Phase1)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);
        }

        [Given(@"a payment of £1000 is not sent in Period R07 2021")]
        public void GivenAPaymentIsNotSent()
        {
        }

        [Given(@"Learner data is updated with a Break in Learning before the first payment due date")]
        public void GivenABreakInLearningBeforeTheFirstPayment()
        {
            throw new NotImplementedException();
        }

        [When(@"the Learner Match is run in Period R(.*) (.*)")]
        public async Task WhenTheLearnerMatchIsRunInPeriodR(byte period, short year)
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(period, year);
            await Helper.LearnerMatchOrchestratorHelper.Run();
        }

        [When(@"the earnings are recalculated")]
        public void WhenTheEarningsAreRecalculated()
        {
        }
    }
}
