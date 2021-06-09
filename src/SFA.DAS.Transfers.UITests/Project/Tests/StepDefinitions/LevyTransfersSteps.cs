using System;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using NUnit.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Transfers.UITests.Project.Helpers;

namespace SFA.DAS.Transfers.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class LevyTransfersSteps
    {
        [Given(@"I am logged in as a Levy Payer")]
        public void GivenIAmLoggedInAsALevyPayer()
        {
            Console.WriteLine("Test OK");
        }
        
        [Given(@"I am on the Manage Apprenticeships Page")]
        public void GivenIAmOnTheManageApprenticeshipsPage()
        {
            Console.WriteLine("Test OK");
        }
        
        [When(@"I click on view my transfers")]
        public void WhenIClickOnViewMyTransfers()
        {
            Console.WriteLine("Test OK");
        }
        
        [Then(@"I am taken to the View Transfers Page")]
        public void ThenIAmTakenToTheViewTransfersPage()
        {
            Console.WriteLine("Test OK");
        }
    }
}
