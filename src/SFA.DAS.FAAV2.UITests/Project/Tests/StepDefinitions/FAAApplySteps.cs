using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FAAV2.UITests.Project.Tests.StepDefinitions;

[Binding]
public class FAAApplySteps(ScenarioContext context)
{
    private readonly FAAStepsHelper _faaStepsHelper = new(context);

    [When(@"the Applicant can apply for a Vacancy in FAA")]
    [Then(@"the Applicant can apply for a Vacancy in FAA")]
    public void TheApplicantCanApplyForAVacancyInFAA() => _faaStepsHelper.ApplyForAVacancy().PreviewApplication().SubmitApplication();

    [Then(@"the candidate can apply for their first vacancy")]
    public void TheCandidateCanApplyForTheirFirstVacancy()
    {
        context.Get<ObjectContext>().SetVacancyReference("1000080193");

        context.Get<VacancyTitleDatahelper>().SetVacancyTitile("AcRsHeLnlP_18Jun2024_00091162670");

        context.Get<AdvertDataHelper>().SetAdditionalQuestion1("bqnySaUYoTEUfWUpXYHI");

        context.Get<AdvertDataHelper>().SetAdditionalQuestion2("dbUbKXYufFtHaJFUsWJe");

        _faaStepsHelper.ApplyForFirstVacancy(true, true, true, true, true, true).PreviewApplication().SubmitApplication();
    }
}
