using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class SoleTraderDOBPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "date of birth?";

        public SoleTraderDOBPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}


