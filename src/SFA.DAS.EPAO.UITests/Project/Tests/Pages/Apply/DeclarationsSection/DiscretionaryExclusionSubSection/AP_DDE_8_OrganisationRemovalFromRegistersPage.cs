using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection
{
    public class AP_DDE_8_OrganisationRemovalFromRegistersPage : EPAO_BasePage
    {
        protected override string PageTitle => "Organisation removal from registers";
        private readonly ScenarioContext _context;

        public AP_DDE_8_OrganisationRemovalFromRegistersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DDE_9_DirectionAndSanctionsPage SelectNoOptionAndContinueInOrganisationRemovalFromRegistersPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "M_DEL-26_1");
            Continue();
            return new AP_DDE_9_DirectionAndSanctionsPage(_context);
        }
    }
}
