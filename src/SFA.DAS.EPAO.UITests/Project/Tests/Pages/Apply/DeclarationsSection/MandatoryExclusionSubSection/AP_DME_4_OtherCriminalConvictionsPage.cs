using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.MandatoryExclusionSubSection
{
    public class AP_DME_4_OtherCriminalConvictionsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Other criminal convictions";
        private readonly ScenarioContext _context;

        public AP_DME_4_OtherCriminalConvictionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DDE_1_TaxAndSocialSecurityIrregularitiesPage SelectNoOptionAndContinueInOtherCriminalConvictionsPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "M_DEL-12_1");
            Continue();
            return new AP_DDE_1_TaxAndSocialSecurityIrregularitiesPage(_context);
        }
    }
}
