using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection
{
    public class AP_DDE_6_ContractsWithdrawnFromYouPage : EPAO_BasePage
    {
        protected override string PageTitle => "Contracts withdrawn from you";
        private readonly ScenarioContext _context;

        public AP_DDE_6_ContractsWithdrawnFromYouPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DDE_7_ContractsYouHaveWithdrawnFromPage SelectNoOptionAndContinueInContractsWithdrawnFromYouPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "M_DEL-24_1");
            Continue();
            return new AP_DDE_7_ContractsYouHaveWithdrawnFromPage(_context);
        }
    }
}
