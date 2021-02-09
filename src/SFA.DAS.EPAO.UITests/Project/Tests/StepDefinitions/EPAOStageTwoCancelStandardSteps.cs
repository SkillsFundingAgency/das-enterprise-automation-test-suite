using SFA.DAS.Login.Service.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.Login.Service;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EPAOStageTwoCancelStandardSteps : EPAOBaseSteps
    {
        private readonly ScenarioContext _context;
        private readonly ApplyStepsHelper _applyStepsHelper;

        protected EPAOStageTwoCancelStandardSteps(ScenarioContext context) : base(context)
        {
            _context = context;
            _applyStepsHelper = new ApplyStepsHelper(context);
        }

        [Given(@"Stage one approved EPAO logs in to apply for a first standard")]
        public void GivenStageOneApprovedEPAOLogsInToApplyForAFirstStandard()
        {
            loggedInHomePage =  ePAOHomePageHelper.StageTwoEPAOStandardCancelUser(_context.GetUser<EPAOStageTwoStandardCancelUser>());
        }
        
        [When(@"Starts the journey to apply for the first standard")]
        [Given(@"Starts the journey to apply for the first standard")]
        public void GivenStartsTheJourneyToApplyForTheFirstStandard()
        {
            _applyStepsHelper.CancelStageTwoStandard();

        }

        [Then(@"EPAO cancels the standard using cancel link as incorrect standard selected")]
        public void ThenEPAOCancelsTheStandardUsingCancelLinkAsIncorrectStandardSelected()
        {
            _applyStepsHelper.ClickCancelYourStandardLink();
        }

    }
}