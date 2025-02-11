using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Employer;

public abstract class Employer_BaseSteps(ScenarioContext context) : AppEmp_BaseSteps(context)
{
    protected Employer_NetworkHubPage networkHubPage;

    protected void EmployerSign(EasAccountUser user) => EmployerSign(() => new EmployerPortalLoginHelper(context).Login(user, true));

    protected void EmployerSign(MultipleEasAccountUser user) => EmployerSign(() => new MultipleAccountsLoginHelper(context, user).Login(user, true));

    private static void EmployerSign(Func<HomePage> func) => func().GoToAanHomePage();
}