using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class UnsuccessfulApplicationsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Have you submitted an application to join the APAR in the last 12 months?";

        public UnsuccessfulApplicationsPage(ScenarioContext context) : base(context) => VerifyPage();

        public EnterUkprnPage SelectNoFor2ApplicaitonsAndContinue()
        {
            SelectNoAndContinue();
            return new EnterUkprnPage(context);
        }
    }
}
