using SFA.DAS.API.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprenticeCommitmentsAPISteps
    {

        private readonly ApprenticeCommitmentsRestClient _restClient;

        public ApprenticeCommitmentsAPISteps(ScenarioContext context) => _restClient = new ApprenticeCommitmentsRestClient(context.GetApiSubscriptionKeyConfig<ApiFrameworkConfig>().Fatv2ApiKey);

        [When(@"an apprenticeship is posted")]
        public void WhenAnApprenticeshipIsPosted()
        {
            throw new PendingStepException();
        }

    }
}
