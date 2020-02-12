using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public abstract class HowHasTheTeamOrPersonWorked : RoatpBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea => By.CssSelector("textarea");

        public HowHasTheTeamOrPersonWorked(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public TellUsWhoIsTheManagerPage EnterHowHasTheTeamOrPersonWorked()
        {
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.HowHasTheTeamOrPersonWorked);
            Continue();
            return new TellUsWhoIsTheManagerPage(_context);
        }
    }
}