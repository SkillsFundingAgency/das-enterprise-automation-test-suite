using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "CreateIncentive")]
    public class CreateIncentiveSteps : StepsBase
    {
        private DateTime _initialStartDate;
        private List<ApprenticeshipIncentive> _incentives;

        protected CreateIncentiveSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"an existing withdrawn incentive")]
        public async Task GivenAnExistingWithdrawnIncentive()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(11, 2021);

            _initialStartDate = new DateTime(2021, 4, 5);

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, _initialStartDate,
                    _initialStartDate.AddYears(-24), Context.ScenarioInfo.Title, Phase.Phase1)
                .Create();

            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);

            await Helper.EISqlHelper.Execute($"UPDATE [incentives].[ApprenticeshipIncentive] SET [Status] = 'Withdrawn' WHERE [Id] = '{TestData.ApprenticeshipIncentiveId}'");
        }

        [Given(@"an employer is re-applying for apprenticeship incentive")]
        public async Task GivenAnEmployerIsRe_ApplyingForApprenticeshipIncentive()
        {
            await Helper.CollectionCalendarHelper.SetActiveCollectionPeriod(1, 2122);

            TestData.IncentiveApplication = new IncentiveApplicationBuilder()
                .WithAccount(TestData.Account)
                .WithApprenticeship(TestData.ApprenticeshipId, TestData.ULN, TestData.UKPRN, _initialStartDate.AddMonths(4),
                    _initialStartDate.AddYears(-24), Context.ScenarioInfo.Title, Phase.Phase2)
                .Create();

        }
        
        [When(@"they submit the application")]
        public async Task WhenTheySubmitTheApplication()
        {
            await Helper.IncentiveApplicationHelper.Submit(TestData.IncentiveApplication);
        }

        [Then(@"a new apprenticeship incentive is created")]
        public void ThenANewApprenticeshipIncentiveIsCreated()
        {
            _incentives = Helper.EISqlHelper.GetAllFromDatabase<ApprenticeshipIncentive>()
                .Where(i => i.ApprenticeshipId == TestData.ApprenticeshipId).ToList();

            _incentives.Should().HaveCount(2);
            _incentives.Where(i => i.Status == IncentiveStatus.Active).Should().HaveCount(1);
        }
        
        [Then(@"original withdrawn incentive is retained")]
        public void ThenOriginalWithdrawnIncentiveIsRetained()
        {
            _incentives.Where(i => i.Status == IncentiveStatus.Withdrawn).Should().HaveCount(1);
        }
    }
}
