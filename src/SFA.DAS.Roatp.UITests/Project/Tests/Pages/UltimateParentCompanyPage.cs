using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class UltimateParentCompanyPage : RoatpBasePage
    {
        protected override string PageTitle => "Does your organisation have an ultimate parent company in the UK?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UltimateParentCompanyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ParentCompanyDetailsPage SelectYesForUltimateParentCompanyAndContinue()
        {
            SelectRadioOptionByForAttribute("YO-20");
            Continue();
            return new ParentCompanyDetailsPage(_context);
        }
    }
}
