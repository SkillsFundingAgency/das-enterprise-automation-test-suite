using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FAAV2.UITests.Project.Tests.StepDefinitions;

[Binding]
public class FAAApplySteps(ScenarioContext context)
{
    private readonly FAAStepsHelper _faaStepsHelper = new(context);

    [When(@"the Applicant can apply for a Vacancy in FAA")]
    [Then(@"the Applicant can apply for a Vacancy in FAA")]
    public void TheApplicantCanApplyForAVacancyInFAA() => ApplyForAVacancy(false);

    [Then(@"the candidate can apply for their first vacancy")]
    public void TheCandidateCanApplyForTheirFirstVacancy() => SetVacancyDetailsAndApplyForAVacancy(true);

    [Then(@"the candidate can apply for vacancy")]
    public void ThenTheCandidateCanApplyForVacancy() => SetVacancyDetailsAndApplyForAVacancy(false);

    private void SetVacancyDetailsAndApplyForAVacancy(bool firstVacancy)
    {
        context.Get<ObjectContext>().SetVacancyReference("1000079780");

        context.Get<VacancyTitleDatahelper>().SetVacancyTitile("AmcqCwjaNa_22May2024_00261048235");

        context.Get<AdvertDataHelper>().SetAdditionalQuestion1("rWmVeUPzTPZtbnzLVGnP");

        context.Get<AdvertDataHelper>().SetAdditionalQuestion2("kZmZPiuBqqoYSdxSLYvX");

        ApplyForAVacancy(firstVacancy);
    }

    private void ApplyForAVacancy(bool firstVacancy)
    {
        var page = firstVacancy ? _faaStepsHelper.ApplyForFirstVacancy(true, true, true, true, true, true) : _faaStepsHelper.ApplyForAVacancy();
        
        page.PreviewApplication().SubmitApplication();
    }

}
