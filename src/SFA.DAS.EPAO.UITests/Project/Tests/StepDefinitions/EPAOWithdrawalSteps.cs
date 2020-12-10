using SFA.DAS.EPAO.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions.EPAOWithdrawalStepDefs
{
    [Binding]
    public class EPAOWithdrawalSteps : EPAOBaseSteps
    {
        private readonly ScenarioContext _context;
        private readonly EPAOWithdrawalHelper _ePAOWithdrawalHelper;

        public EPAOWithdrawalSteps(ScenarioContext context) : base(context)
        {
            _context = context;
            _ePAOWithdrawalHelper = new EPAOWithdrawalHelper(context);
            
        }

        [When(@"starts the journey to withdraw a standard")]
        [Given(@"starts the journey to withdraw a standard")]
        public void GivenStartsTheJourneyToWithdrawAStandard()
        {
            //EPAOWithdrawalHelper _ePAOWithdrawalHelper = new EPAOWithdrawalHelper(_context);
            _ePAOWithdrawalHelper.StartOfStandardWithdrawalJourney();
        }

        [When(@"completes the standard withdrawal notification questions")]
        public void WhenCompletesTheStandardWithdrawalNotificationQuestions()
        {
            _ePAOWithdrawalHelper.StandardApplicationFinalJourney();
        }

        [Then(@"application is submitted for review")]
        public void ThenApplicationIsSubmittedForReview()
        {
            _ePAOWithdrawalHelper.VerifyStandardSubmitted();
        }

        [Given(@"user verifies the different statuses of the standard withdrawl application")]
        public void GivenUserVerifiesTheDifferentStatusesOfTheStandardWithdrawlApplication()
        {
            _ePAOWithdrawalHelper.VerifyTheInProgressStatus();
        }


        [Given(@"user verfifies view links navigates to the appropriate corresponding page")]
        public void GivenUserVerfifiesViewLinksNavigatesToTheAppropriateCorrespondingPage()
        {
            ScenarioContext.Current.Pending();
        }



    }
}
