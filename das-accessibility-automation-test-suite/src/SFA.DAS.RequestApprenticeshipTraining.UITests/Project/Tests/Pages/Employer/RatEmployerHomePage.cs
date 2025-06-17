namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Employer;

public class RatEmployerHomePage(ScenarioContext context) : HomePage(context)
{
    public FindApprenticeshipTrainingAndManageRequestsPage GoToRatHomePage()
    {
        formCompletionHelper.Click(FindApprenticeshipLink);

        return new FindApprenticeshipTrainingAndManageRequestsPage(context);
    }
}