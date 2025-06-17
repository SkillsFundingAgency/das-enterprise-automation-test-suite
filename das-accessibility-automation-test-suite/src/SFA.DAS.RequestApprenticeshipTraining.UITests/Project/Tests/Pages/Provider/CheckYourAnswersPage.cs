namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Provider;

public class CheckYourAnswersPage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "Check your answers";

    public WeHaveSharedYourDetailsPage SubmitAnswers()
    {
        Continue();

        return new(context);
    }
}
