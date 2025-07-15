using SFA.DAS.Login.Service.Project;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions;

[Binding]
public class FAAApplySteps(ScenarioContext context)
{
    private readonly FAAStepsHelper _faaStepsHelper = new(context);

    [When(@"the Applicant can apply for a Vacancy in FAA")]
    [Then(@"the Applicant can apply for a Vacancy in FAA")]
    public void TheApplicantCanApplyForAVacancyInFAA()
    {
        var user = context.GetUser<FAAApplyUser>();
        _faaStepsHelper.ApplyForAVacancy("both", user).PreviewApplication().SubmitApplication();
    }

    [When(@"the Applicant can apply for a foundation vacancy in FAA")]
    [Then(@"the Applicant can apply for a foundation vacancy in FAA")]
    public void TheApplicantCanApplyForAFoundationVacancyInFAA()
    {
        var user = context.GetUser<FAAFoundationUser>();
        _faaStepsHelper.ApplyForAVacancy("both", user).PreviewApplication().SubmitApplication();
    }

    [When("the apprentice has submitted their first application")]
    public void GivenTheApprenticeHasSubmittedTheirFirstApplication() => _faaStepsHelper.ApplyForAVacancyWithNewAccount(true, true, true, true, true, true).PreviewApplication().SubmitApplication();

    [When(@"the Applicant can apply for a Vacancy in FAA with ""(.*)"" additional questions")]
    public void TheApplicantCanApplyForAVacancyInFAA(string numberOfQuestions)
    {
        var user = context.GetUser<FAAApplyUser>();
        _faaStepsHelper.ApplyForAVacancy(numberOfQuestions, user).PreviewApplication().SubmitApplication();
    }

    [When(@"multiple Applicants can apply for a Vacancy in FAA")]
    public void MultipleApplicantsCanApplyForAVacancyInFAA() {
        var user1 = context.GetUser<FAAApplyUser>();
        var user2 = context.GetUser<FAAApplySecondUser>();
        _faaStepsHelper.ApplyForAVacancy("both", user1).PreviewApplication().SubmitApplication().ClickSignOut();
        _faaStepsHelper.ApplyForAVacancy("both", user2).PreviewApplication().SubmitApplication();
    } 
}
