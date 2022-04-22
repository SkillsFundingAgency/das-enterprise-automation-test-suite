using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public abstract class CheckProviderPage : CheckPage
    {
        private readonly CheckPageInteractionHelper checkPageInteractionHelper;

        public CheckProviderPage(ScenarioContext context) : base(context) => checkPageInteractionHelper = context.Get<CheckPageInteractionHelper>();

        public override bool IsPageDisplayed() => checkPageInteractionHelper.IsElementDisplayed(() => checkPageInteractionHelper.VerifyPage(Identifier));
    }
}
