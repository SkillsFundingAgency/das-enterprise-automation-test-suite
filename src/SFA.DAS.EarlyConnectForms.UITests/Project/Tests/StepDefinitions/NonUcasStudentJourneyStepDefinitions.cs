using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NonUcasStudentJourneyStepDefinitions
    {

        [Given(@"I am on the landing page for a region '([^']*)'")]
        public void GivenIAmOnTheLandingPageForARegion(string lepCode)
        {
            throw new PendingStepException();
        }

        //[Given(@"I am the landing page for a region '([^']*)'")]
        //public void GivenIAmTheLandingPageForARegion(string lepCode)
        //{
        //    throw new PendingStepException();
        //}

    }
}
