using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SupportSteps
    {
        protected readonly ApprenticeDataHelper apprenticeDataHelper;

        public SupportSteps(ScenarioContext context) => apprenticeDataHelper = context.GetValue<ApprenticeDataHelper>();

        [Then(@"([1-9]) ULN can be generated")]
        public void ThenARandomULNCanBeGenerated(int noOfUln)
        {
            for (int i = 0; i < noOfUln; i++)
            {
                apprenticeDataHelper.Uln();
            }
        }
    }
}