namespace SFA.DAS.FAAV2.UITests.Project;

[Binding]
public class Hooks(ScenarioContext context)
{
    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    [BeforeScenario(Order = 32)]
    public void SetUpHelpers()
    {
        bool isCloneVacancy = context.ScenarioInfo.Tags.Contains("clonevacancy");

        var pageInteractionHelper = context.Get<PageInteractionHelper>();

        context.Set(new VacancyTitleDatahelper(isCloneVacancy));

        context.Set(new FAADataHelper());

        context.Set(new VacancyReferenceHelper(pageInteractionHelper, _objectContext));

        if (context.ScenarioInfo.Tags.Contains("faaapplytestdataprep")) context.Set(new AdvertDataHelper());
    }
}
