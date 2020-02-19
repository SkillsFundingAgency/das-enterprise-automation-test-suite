using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{

    public class ChooseProviderRoutePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Choose your organisation's provider route";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ChooseProviderRoutePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public TermsConditionsMakingApplicationPage SelectApplicationRouteAsMain()
        {
            SelectRadioOptionByForAttribute("route-1");
            Continue();
            return new TermsConditionsMakingApplicationPage(_context);
        }

        public LevyPayingEmployerPage SelectApplicationRouteAsEmployer()
        {
            SelectRadioOptionByForAttribute("route-2");
            Continue();
            return new LevyPayingEmployerPage(_context);
        }

        public TermsConditionsMakingApplicationPage SelectApplicationRouteAsSupporting()
        {
            SelectRadioOptionByForAttribute("route-3");
            Continue();
            return new TermsConditionsMakingApplicationPage(_context);
        }
    }
}
