using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ApplicationDateDeterminedPage : RoatpAdminBasePage
    {
        protected override string PageTitle => "What is the application determined date for this organisation?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector(".govuk-button[value='Continue']");

        private By Day => By.CssSelector("'#Day");

        private By Month => By.CssSelector("#Month");

        private By Year => By.CssSelector("#Year");

        public ApplicationDateDeterminedPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ConfirmDetailsPage EnterDob()
        {
            var dob = admindataHelpers.Dob;
            formCompletionHelper.EnterText(Day, dob.Day);
            formCompletionHelper.EnterText(Month, dob.Month);
            formCompletionHelper.EnterText(Year, dob.Year);
            Continue();
            return new ConfirmDetailsPage(_context);
        }

    }
}
