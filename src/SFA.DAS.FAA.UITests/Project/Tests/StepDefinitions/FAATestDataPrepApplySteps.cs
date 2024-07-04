namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions;

[Binding, Scope(Tag = "faaapplytestdataprep")]
public class FAATestDataPrepApplySteps(ScenarioContext context)
{
    private readonly FAAStepsHelper _faaStepsHelper = new(context);

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
