using TechTalk.SpecFlow;

public class ApprenticeObjectContext
{
    private readonly ScenarioContext context;

    public ApprenticeObjectContext(ScenarioContext context)
    {
        this.context = context;
    }

    public string GetApprenticeEmail()
    {
        return context.Get<string>("ApprenticeEmail");
    }

    public void SetRegistrationId(string registrationId)
    {
        context.Set(registrationId, "RegistrationIdKey");
    }

    public void SetTrainingName(string trainingName)
    {
        context.Set(trainingName, "TrainingNameKey");
    }

    public void SetTrainingStartDate(string trainingStartDate)
    {
        context.Set(trainingStartDate, "TrainingStartDateKey");
    }
    public void SetExpectedUserName(string fullName)
    {
        context.Set(fullName, "ExpectedFullUserNameKey");
    }
    public string GetExpectedUserName()
    {
        return context.Get<string>("ExpectedFullUserNameKey");
    }

    public string GetFirstName() => context.Get<string>("FirstNameKey");
    public string GetLastName() => context.Get<string>("LastNameKey");
}