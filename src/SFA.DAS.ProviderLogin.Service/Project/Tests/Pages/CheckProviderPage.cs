using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public abstract class CheckProviderPage : CheckPage
    {
        public CheckProviderPage(ScenarioContext context) : base(context) { }

        public override bool IsPageDisplayed() => pageInteractionHelper.IsElementDisplayed(() => VerifyPage(Identifier));
    }
}
