using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Employer;

public abstract class Employer_BaseSteps : AppEmp_BaseSteps
{
    protected Employer_NetworkHubPage networkHubPage;

    public Employer_BaseSteps(ScenarioContext context) : base(context)
    {
        
    }

    protected void EmployerSign(EasAccountUser user) => new StubSignInPage(context).Login(user).Continue();
}