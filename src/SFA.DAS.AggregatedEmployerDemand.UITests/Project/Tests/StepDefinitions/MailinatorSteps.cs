using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MailinatorSteps
    {
        private readonly AEDMailinatorStepsHelper _aEDMailinatorStepsHelper;

        public MailinatorSteps(ScenarioContext context) => _aEDMailinatorStepsHelper = new AEDMailinatorStepsHelper(context);

        [Then(@"confirm the user is able to verify the email '(.*)'")]
        public void ThenConfirmTheUserIsAbleToVerifyTheEmail(string organisationEmailAddress) => _aEDMailinatorStepsHelper.OpenLink(organisationEmailAddress);
    }
}
