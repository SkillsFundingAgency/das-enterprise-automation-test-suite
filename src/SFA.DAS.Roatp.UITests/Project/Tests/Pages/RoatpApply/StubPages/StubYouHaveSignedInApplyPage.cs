using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.StubPages
{
    public class StubYouHaveSignedInApplyPage : StubYouHaveSignedInBasePage
    {

        public StubYouHaveSignedInApplyPage(ScenarioContext context, string username, string idOrUserRef, bool newUser) : base(context, username, idOrUserRef, newUser)
        {
            
        }

        public new void Continue() => base.Continue();
    }
}
