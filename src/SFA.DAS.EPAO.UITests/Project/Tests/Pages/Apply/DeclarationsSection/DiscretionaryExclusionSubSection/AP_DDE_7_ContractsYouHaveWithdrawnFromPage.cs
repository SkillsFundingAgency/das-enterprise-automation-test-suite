using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection
{
    public class AP_DDE_7_ContractsYouHaveWithdrawnFromPage : EPAO_BasePage
    {
        protected override string PageTitle => "Contracts you have withdrawn from";
        private readonly ScenarioContext _context;

        public AP_DDE_7_ContractsYouHaveWithdrawnFromPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DDE_8_OrganisationRemovalFromRegistersPage SelectNoOptionAndContinueInContractsYouHaveWithdrawnFromPage()
        {
            SelectRadioOptionByForAttribute("A_DEL-25_1");
            Continue();
            return new AP_DDE_8_OrganisationRemovalFromRegistersPage(_context);
        }
    }
}
