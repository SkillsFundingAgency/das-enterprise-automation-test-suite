using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection
{
    public class AP_DDE_3_CessationOfTradingPage : EPAO_BasePage
    {
        protected override string PageTitle => "Cessation of trading";
        
        public AP_DDE_3_CessationOfTradingPage(ScenarioContext context) : base(context) => VerifyPage();

        public AP_DDE_4_IncorrectTaxReturnsPage SelectNoOptionAndContinueInCessationOfTradingPage()
        {
            SelectRadioOptionByForAttribute("A_DEL-21_1");
            Continue();
            return new AP_DDE_4_IncorrectTaxReturnsPage(context);
        }
    }
}
