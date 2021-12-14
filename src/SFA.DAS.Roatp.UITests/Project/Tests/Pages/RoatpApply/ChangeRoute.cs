using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class ChangeRoutePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Changing your provider route";
        
        public ChangeRoutePage(ScenarioContext context) : base(context) => VerifyPage();

        public ChooseProviderRoutePage SelectYesToChangeRouteAndContinue()
        {
            SelectYesAndContinue();
            return new ChooseProviderRoutePage(context);
        }

        public ApplicationOverviewPage SelectNoToChangeRouteAndContinue()
        {
            SelectNoAndContinue();
            return new ApplicationOverviewPage(context);
        }
    }
}