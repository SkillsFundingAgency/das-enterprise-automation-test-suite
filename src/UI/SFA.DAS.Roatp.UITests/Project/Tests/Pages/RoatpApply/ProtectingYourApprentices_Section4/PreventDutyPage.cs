using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ProtectingYourApprentices_Section4
{
    public class PreventDutyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation's safeguarding policy include its responsibilities towards the Prevent duty?";

        public PreventDutyPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage SelectYesForPreventDutyPageAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new ApplicationOverviewPage(context);
        }
    }
}
