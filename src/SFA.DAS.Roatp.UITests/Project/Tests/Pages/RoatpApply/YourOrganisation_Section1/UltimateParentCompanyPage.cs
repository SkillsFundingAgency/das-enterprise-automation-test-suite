using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class UltimateParentCompanyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation have an ultimate parent company in the UK?";

        public UltimateParentCompanyPage(ScenarioContext context) : base(context) => VerifyPage();

        public ParentCompanyDetailsPage SelectYesForUltimateParentCompanyAndContinue()
        {
            SelectRadioOptionByForAttribute("YO-20");
            Continue();
            return new ParentCompanyDetailsPage(_context);
        }
        public ParentCompanyDetailsPage ClickContinueParentCompanyOption()
        {
            Continue();
            return new ParentCompanyDetailsPage(_context);
        }

    }
}
