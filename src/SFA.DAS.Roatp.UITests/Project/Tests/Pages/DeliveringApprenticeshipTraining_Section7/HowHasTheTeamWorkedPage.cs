using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class HowHasTheTeamWorkedPage : RoatpBasePage
    {
        protected override string PageTitle => "How has the team worked with other organisations and employers to develop and deliver training?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea => By.CssSelector("textarea");

        public HowHasTheTeamWorkedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public TellUsWhoIsTheManagerPage EnterHowHasTheTeamWorked()
        {
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.HowHasTheTeamWorked);
            Continue();
            return new TellUsWhoIsTheManagerPage(_context);
        }
    }
}


