using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection
{
    public class AP_DDE_1_TaxAndSocialSecurityIrregularitiesPage : EPAO_BasePage
    {
        protected override string PageTitle => "Tax and social security irregularities";
        private readonly ScenarioContext _context;

        public AP_DDE_1_TaxAndSocialSecurityIrregularitiesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DDE_2_BankruptcyAndInsolvencyPage SelectNoOptionInTaxAndSocialSecurityIrregularitiesPage()
        {
            SelectRadioOptionByForAttribute("D_DEL-13_1");
            Continue();
            return new AP_DDE_2_BankruptcyAndInsolvencyPage(_context);
        }
    }
}
