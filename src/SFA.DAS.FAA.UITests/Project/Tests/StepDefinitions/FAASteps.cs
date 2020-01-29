using NUnit.Framework;
using SFA.DAS.FAA.UITests.Project.Helpers;
using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAASteps
    {
        private readonly FAAStepsHelper _faaStepsHelper;
        private FAA_CreateAnAccountPage accountCreationPage;

        public FAASteps(ScenarioContext context) => _faaStepsHelper = new FAAStepsHelper(context);

        [When(@"the Applicant withdraw the application")]
        public void WhenTheApplicantWithdrawTheApplication() => _faaStepsHelper.WithdrawVacancy();

        [When(@"an Applicant initiates Account creation journey")]
        public void WhenAnApplicantInitiatesAccountCreationJourney() => accountCreationPage = _faaStepsHelper.StartFAAAccountCreation();

        [Then(@"the Applicant is able to create a FAA Account")]      
        
        public void ThenTheApplicantIsAbleToCreateAFAAAccount() => _faaStepsHelper.CreateFAAAccount(accountCreationPage);

        [Then(@"the status of the Application is shown as '(successful|unsuccessful)' in FAA")]
        public void ThenTheStatusOfTheApplicationIsShownAsInFAA(string expectedStatus)
        {
            var actualStatus = _faaStepsHelper.GetApplicationStatus();

            StringAssert.Contains(expectedStatus, actualStatus);
        }

        [Then(@"the Applicant should be told that Email is already registered")]
        public void ThenTheApplicantShouldBeToldThatEmailIsAlreadyRegistered() 
        {
            accountCreationPage.SubmitAccountCreationDetailsWithRegisteredEmail();
        }
    }
}