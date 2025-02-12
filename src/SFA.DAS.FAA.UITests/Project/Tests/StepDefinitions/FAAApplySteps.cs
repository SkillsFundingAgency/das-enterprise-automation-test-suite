namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions;

[Binding]
public class FAAApplySteps(ScenarioContext context)
{
    private readonly FAAStepsHelper _faaStepsHelper = new(context);

    [When(@"the Applicant can apply for a Vacancy in FAA")]
    [Then(@"the Applicant can apply for a Vacancy in FAA")]
    public void TheApplicantCanApplyForAVacancyInFAA() => _faaStepsHelper.ApplyForAVacancy().PreviewApplication().SubmitApplication();

    [When("the apprentice has submitted their first application")]
    public void GivenTheApprenticeHasSubmittedTheirFirstApplication() => _faaStepsHelper.ApplyForAVacancyWithNewAccount(true, true, true, true, true, true).PreviewApplication().SubmitApplication();
}
