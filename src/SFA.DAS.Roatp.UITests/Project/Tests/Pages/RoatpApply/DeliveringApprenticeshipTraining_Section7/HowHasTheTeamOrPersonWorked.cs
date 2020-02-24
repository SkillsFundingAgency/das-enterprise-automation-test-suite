using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public abstract class HowHasTheTeamOrPersonWorked : RoatpApplyBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public HowHasTheTeamOrPersonWorked(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public TellUsWhoIsTheManagerPage EnterHowHasTheTeamOrPersonWorked()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.HowHasTheTeamOrPersonWorked);
            return new TellUsWhoIsTheManagerPage(_context);
        }
    }
}