using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class CheckPageUsingShorterTimeOut : CheckPage
    {
        protected readonly CheckPageInteractionHelper checkPageInteractionHelper;

        public CheckPageUsingShorterTimeOut(ScenarioContext context) : base(context) => checkPageInteractionHelper = context.Get<CheckPageInteractionHelper>();

        public override bool IsPageDisplayed() => checkPageInteractionHelper.WithoutImplicitWaits(() => checkPageInteractionHelper.VerifyPage(Identifier));
    }
}
