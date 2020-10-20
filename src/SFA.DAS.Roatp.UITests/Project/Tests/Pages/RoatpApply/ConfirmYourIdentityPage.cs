using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class ConfirmYourIdentityPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Confirm your identity";
        
        public ConfirmYourIdentityPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
