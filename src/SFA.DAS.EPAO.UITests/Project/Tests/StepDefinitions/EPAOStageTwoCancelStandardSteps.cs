namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions;

[Binding]
public class EPAOStageTwoCancelStandardSteps : EPAOBaseSteps
{
    protected EPAOStageTwoCancelStandardSteps(ScenarioContext context) : base(context) { }

    [Given(@"Stage one approved EPAO logs in to apply for a first standard")]
    public void GivenStageOneApprovedEPAOLogsInToApplyForAFirstStandard() => 
        loggedInHomePage = ePAOHomePageHelper.StageTwoEPAOStandardCancelUser(context.GetUser<EPAOStageTwoStandardCancelUser>());
    

    [When(@"Starts the journey to apply for the first standard")]
    [Given(@"Starts the journey to apply for the first standard")]
    public void GivenStartsTheJourneyToApplyForTheFirstStandard() => applyStepsHelper.ApplyStageTwoStandard();

    [Then(@"EPAO cancels the standard using cancel link as incorrect standard selected")]
    public void ThenEPAOCancelsTheStandardUsingCancelLinkAsIncorrectStandardSelected() => new CancelStandardStepsHelper(context).CancelYourStandard();

}