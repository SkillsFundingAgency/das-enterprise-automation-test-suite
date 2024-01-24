using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{

    public class ChooseProviderRoutePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Choose your organisation's provider route";

        public ChooseProviderRoutePage(ScenarioContext context) : base(context) => VerifyPage();

        public TermsConditionsMakingApplicationPage SelectApplicationRouteAsMain()
        {
            SelectRadioOptionByForAttribute("route-1");
            Continue();
            return new TermsConditionsMakingApplicationPage(context);
        }

        public LevyPayingEmployerPage SelectApplicationRouteAsEmployer()
        {
            SelectRadioOptionByForAttribute("route-2");
            Continue();
            return new LevyPayingEmployerPage(context);
        }

        public TermsConditionsMakingApplicationPage SelectApplicationRouteAsSupporting()
        {
            SelectRadioOptionByForAttribute("route-3");
            Continue();
            return new TermsConditionsMakingApplicationPage(context);
        }
    }
}
