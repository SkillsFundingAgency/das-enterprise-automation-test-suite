using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection
{
    public class AP_DDE_11_PublicbodyFundsAndContractsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Public body funds and contracts";
        private readonly ScenarioContext _context;

        public AP_DDE_11_PublicbodyFundsAndContractsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DDE_12_LegalDisputePage SelectNoOptionAndContinueInPublicbodyFundsAndContractsPage()
        {
            SelectRadioOptionByForAttribute("A_DEL-29_1");
            Continue();
            return new AP_DDE_12_LegalDisputePage(_context);
        }
    }
}
