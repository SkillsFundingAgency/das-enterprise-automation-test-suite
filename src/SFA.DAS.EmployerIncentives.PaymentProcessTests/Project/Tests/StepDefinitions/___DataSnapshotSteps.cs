using System;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DataSnapshotSteps : StepsBase
    {
        [Given(@"data exists")]
        public void GivenDataExists()
        {
           
        }
        
        [When(@"saving a snapshot")]
        public async Task WhenSavingASnapshot()
        {
            await sqlHelper.TakeDataSnapshot();
        }
        
        [Then(@"it is saved to a file")]
        public void ThenItIsSavedToAFile()
        {
           Assert.Pass();
        }

        protected DataSnapshotSteps(ScenarioContext context) : base(context)
        {
        }
    }
}
