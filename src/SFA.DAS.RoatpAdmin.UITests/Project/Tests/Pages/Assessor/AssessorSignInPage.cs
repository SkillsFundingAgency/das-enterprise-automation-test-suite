using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public class AssessorSignInPage : SignInBasePage
    {
        protected override string PageTitle => "ESFA Sign in";

        public AssessorSignInPage(ScenarioContext context) : base(context) { }

        public void Login(string userName, string password)
        {
            SubmitValidLoginDetails(userName, password);
            pageInteractionHelper.WaitforURLToChange("NewApplications");
        }
    }
}
