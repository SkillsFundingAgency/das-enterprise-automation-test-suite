namespace SFA.DAS.FAAV2.UITests.Project.Tests.StepDefinitions;

[Binding]
public class FAAApplySteps(ScenarioContext context)
{
    private readonly FAAStepsHelper _faaStepsHelper = new(context);

    [When(@"the Applicant can apply for a Vacancy in FAA")]
    [Then(@"the Applicant can apply for a Vacancy in FAA")]
    public void TheApplicantCanApplyForAVacancyInFAA() => _faaStepsHelper.ApplyForAVacancy().PreviewApplication().SubmitApplication();
}
