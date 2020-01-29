using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection
{
    public class AP_DDE_5_HmrcChallengesPage : EPAO_BasePage
    {
        protected override string PageTitle => "HMRC challenges to tax returns";
        private readonly ScenarioContext _context;

        public AP_DDE_5_HmrcChallengesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DDE_6_ContractsWithdrawnFromYouPage SelectNoOptionAndContinueInHmrcChallengesPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "M_DEL-23_1");
            Continue();
            return new AP_DDE_6_ContractsWithdrawnFromYouPage(_context);
        }
    }
}
