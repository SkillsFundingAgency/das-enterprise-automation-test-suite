using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class OrganisationExpectToUseSubcontractorsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation expect to use subcontractors in the first 12 months of joining APAR?";

        public OrganisationExpectToUseSubcontractorsPage(ScenarioContext context) : base(context) => VerifyPage();

        public CarryOutDueDiligencePage YesToUsingSubcontractorsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new CarryOutDueDiligencePage(context);
        }
    }
}
