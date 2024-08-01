using Polly;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers.StubPages
{
    public class RATStubSignInBasePage(ScenarioContext context) : StubSignInBasePage(context)
    {
        protected override string PageTitle => "Stub Authentication - Enter sign in details";

      
      
    }
}
