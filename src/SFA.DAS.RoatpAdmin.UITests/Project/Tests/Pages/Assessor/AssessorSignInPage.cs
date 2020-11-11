using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public class AssessorSignInPage : EsfaSignInPage
    {
        public AssessorSignInPage(ScenarioContext context) : base(context) { }

        public void Login(string userName, string password)
        {
            SubmitValidLoginDetails(userName, password);
            pageInteractionHelper.WaitforURLToChange("New");
        }
    }
}
