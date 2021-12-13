using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9
{
    public class CheckedWithEveryonePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Have you checked with everyone named in this application that the details provided for them are accurate?";

        public CheckedWithEveryonePage(ScenarioContext context) : base(context) => VerifyPage();

        public PermissionFromOrganisationPage SelectYesCheckedWithEveryoneAndContinue()
        {
            SelectYesAndContinue();
            return new PermissionFromOrganisationPage(_context);
        }

        public FinishSectionShutterPage SelectNoCheckedWithEveryoneAndContinue()
        {
            SelectNoAndContinue();
            return new FinishSectionShutterPage(_context);
        }
    }
}
