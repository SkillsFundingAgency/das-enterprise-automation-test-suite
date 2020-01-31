using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class TrusteesDOBPage : RoatpBasePage
    {
        protected override string PageTitle => "Enter the date of birth for trustees";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Dob => By.CssSelector("#dob");

        private By Month => By.CssSelector("input[id*='Month']");

        private By Year => By.CssSelector("input[id*='Year']");

        public TrusteesDOBPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterDateOfBirthForTrusteesForCharity()
        {
            var dobs = pageInteractionHelper.FindElements(Dob).ToList();

            int count = 0;

            foreach (var dob in dobs)
            {
                var dobcalc = applydataHelpers.Dob(count++);
                var month = dob.FindElement(Month);
                formCompletionHelper.EnterText(month, dobcalc.Month);

                var year = dob.FindElement(Year);
                formCompletionHelper.EnterText(year, dobcalc.Year);
            }

            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}


