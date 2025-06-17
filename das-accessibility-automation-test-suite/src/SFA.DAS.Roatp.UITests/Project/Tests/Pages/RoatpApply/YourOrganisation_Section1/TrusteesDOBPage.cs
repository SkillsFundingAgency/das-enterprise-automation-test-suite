using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class TrusteesDOBPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Enter the date of birth for trustees";

        public TrusteesDOBPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}