using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection
{
    public class AP_DDE_4_IncorrectTaxReturnsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Incorrect tax returns";
        private readonly ScenarioContext _context;

        public AP_DDE_4_IncorrectTaxReturnsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DDE_5_HmrcChallengesPage SelectNoOptionAndContinueInTheIncorrectTaxReturnsPage()
        {
            SelectRadioOptionByForAttribute("A_DEL-22_1");
            Continue();
            return new AP_DDE_5_HmrcChallengesPage(_context);
        }
    }
}
