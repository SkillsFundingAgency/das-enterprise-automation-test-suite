using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransformationSteps
    {
        public TransformationSteps(ScenarioContext context) { }

        [StepArgumentTransformation(@"(GET|POST)")]
        public Method HttpMethodTransformation(string method) => Enum.Parse<Method>(method, true);

    }
}
