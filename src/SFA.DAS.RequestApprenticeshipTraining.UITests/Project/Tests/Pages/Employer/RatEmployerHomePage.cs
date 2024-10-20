using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Employer;

public class RatEmployerHomePage(ScenarioContext context) : HomePage(context)
{
    public FindApprenticeshipTrainingAndManageRequestsPage NavigateToFindApprenticeshipPage()
    {
        formCompletionHelper.Click(FindApprenticeshipLink);

        return new FindApprenticeshipTrainingAndManageRequestsPage(context);
    }
}