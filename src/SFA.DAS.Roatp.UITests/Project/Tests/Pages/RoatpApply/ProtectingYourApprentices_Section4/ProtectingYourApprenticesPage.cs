using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ProtectingYourApprentices_Section4
{
    public class ProtectingYourApprenticesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Protecting your apprentices";

        public ProtectingYourApprenticesPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage ClickSaveAndContinue()
        {
            Continue();
            return new ApplicationOverviewPage(context);
        }
    }
}
