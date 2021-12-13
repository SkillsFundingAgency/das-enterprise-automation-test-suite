using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class ChangeUkprnPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Change UKPRN";
        
        public ChangeUkprnPage(ScenarioContext context) : base(context) => VerifyPage();

        public EnterUkprnPage SelectYesToChangeUkprnAndContinue()
        {
            SelectYesAndContinue();
            return new EnterUkprnPage(_context);
        }

        public ApplicationOverviewPage SelectNoToChangeUkprnAndContinue()
        {
            SelectNoAndContinue();
            return new ApplicationOverviewPage(_context);
        }
    }
}