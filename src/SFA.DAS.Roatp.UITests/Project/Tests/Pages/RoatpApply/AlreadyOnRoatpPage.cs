using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class AlreadyOnRoatpPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Your organisation is already on the RoATP as";

        public AlreadyOnRoatpPage(ScenarioContext context) : base(context) => VerifyPage();

        public ChooseProviderRoutePage SelectYesToChangeProviderRouteAndContinue()
        {
            SelectYesAndContinue();
            return new ChooseProviderRoutePage(context);
        }
    }
}
