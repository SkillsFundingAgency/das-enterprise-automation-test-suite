using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.MandatoryExclusionSubSection
{
    public class AP_DME_3_CounterTerrorismPage : EPAO_BasePage
    {
        protected override string PageTitle => "Counter terrorism";
        private readonly ScenarioContext _context;

        public AP_DME_3_CounterTerrorismPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DME_4_OtherCriminalConvictionsPage SelectNoOptionAndContinueInCounterTerrorismPage()
        {
            SelectRadioOptionByForAttribute("M_DEL-11_1");
            Continue();
            return new AP_DME_4_OtherCriminalConvictionsPage(_context);
        }
    }
}
