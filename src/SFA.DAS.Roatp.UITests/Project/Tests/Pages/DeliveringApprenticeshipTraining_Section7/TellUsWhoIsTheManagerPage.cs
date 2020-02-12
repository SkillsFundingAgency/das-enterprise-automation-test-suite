using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class TellUsWhoIsTheManagerPage : RoatpBasePage
    {
        protected override string PageTitle => "Tell us who's the overall manager for this team";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FullName => By.CssSelector(".govuk-input[type='text']");

        public TellUsWhoIsTheManagerPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterDetailsOfTheManager()
        {
            formCompletionHelper.EnterText(FullName, applydataHelpers.FullName);
            SelectRadioOptionByText("Over 18 months");
            Continue();
            return new ApplicationOverviewPage(_context);
        }

        public ApplicationOverviewPage EnterDetailsOfTheManagerPerson()
        {
            formCompletionHelper.EnterText(FullName, applydataHelpers.FullName);
            SelectYesAndContinue();
            return new ApplicationOverviewPage(_context);
        }
    }
}