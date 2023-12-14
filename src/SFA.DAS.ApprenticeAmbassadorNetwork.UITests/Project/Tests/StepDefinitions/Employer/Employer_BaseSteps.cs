using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Employer;

public abstract class Employer_BaseSteps(ScenarioContext context) : AppEmp_BaseSteps(context)
{
    protected Employer_NetworkHubPage networkHubPage;

    protected void EmployerSign(EasAccountUser user) => new StubSignInEmployerPage(context).Login(user).Continue();
}