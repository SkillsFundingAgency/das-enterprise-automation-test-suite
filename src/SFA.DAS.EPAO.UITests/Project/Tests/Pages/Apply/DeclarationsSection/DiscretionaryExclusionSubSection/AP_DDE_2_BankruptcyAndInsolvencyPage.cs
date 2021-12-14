using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection
{
    public class AP_DDE_2_BankruptcyAndInsolvencyPage : EPAO_BasePage
    {
        protected override string PageTitle => "Bankruptcy and insolvency";

        public AP_DDE_2_BankruptcyAndInsolvencyPage(ScenarioContext context) : base(context) => VerifyPage();

        public AP_DDE_3_CessationOfTradingPage SelectNoOptionAndContinueInBankruptcyAndInsolvencyPage()
        {
            SelectRadioOptionByForAttribute("D_DEL-14_1");
            Continue();
            return new AP_DDE_3_CessationOfTradingPage(context);
        }
    }
}
