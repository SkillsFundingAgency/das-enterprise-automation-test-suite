using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class LevyPayingEmployerPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Is your organisation a levy-paying employer?";

        public LevyPayingEmployerPage(ScenarioContext context) : base(context) => VerifyPage();

        public TermsConditionsMakingApplicationPage SelectYesForLevyPayingEmployerAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new TermsConditionsMakingApplicationPage(_context);
        }
    }
}
