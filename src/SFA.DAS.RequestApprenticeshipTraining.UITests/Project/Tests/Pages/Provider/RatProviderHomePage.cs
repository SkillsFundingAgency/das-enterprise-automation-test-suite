using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Provider;

public class RatProviderHomePage(ScenarioContext context) : ProviderHomePage(context, false)
{
    public EmployerRequestsForApprenticeshipTrainingPage NavigateToEmployerRequestPage()
    {
        formCompletionHelper.ClickElement(ViewEmployerRequestsForTraining);

        return new EmployerRequestsForApprenticeshipTrainingPage(context);
    }
}
