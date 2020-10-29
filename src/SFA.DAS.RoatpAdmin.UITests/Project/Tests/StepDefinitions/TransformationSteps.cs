using SFA.DAS.RoatpAdmin.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransformationSteps
    {
        [StepArgumentTransformation(@"(main|supporting|employer)")]
        public ApplicationRoute Applicationroute(string applicationroute) => Enum.Parse<ApplicationRoute>(applicationroute, true);
    }
}
