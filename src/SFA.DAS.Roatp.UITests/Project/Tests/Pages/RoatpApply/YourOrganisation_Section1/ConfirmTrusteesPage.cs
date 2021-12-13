using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class ConfirmTrusteesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Confirm your organisation's trustees";

        public ConfirmTrusteesPage(ScenarioContext context) : base(context) => VerifyPage();

        public TrusteesDOBPage ConfirmTrusteesAndContinue()
        {
            Continue();
            return new TrusteesDOBPage(_context);
        }
    }
}


