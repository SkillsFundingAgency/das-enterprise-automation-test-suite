using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class CriminalAndComplianceChecksPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Criminal and compliance checks on your organisation";

        public CriminalAndComplianceChecksPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage ClickSaveAndContinue()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
