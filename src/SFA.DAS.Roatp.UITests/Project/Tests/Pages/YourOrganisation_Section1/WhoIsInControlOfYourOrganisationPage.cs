using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1
{
    public class WhoIsInControlOfYourOrganisationPage : RoatpBasePage
    {
        protected override string PageTitle => "Who is in control of your organisation?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FullNameField => By.Id("PersonInControlName");

        private By MonthField => By.XPath("(//input[@class='govuk-input govuk-date-input__input govuk-input--width-2 '])[1]");
        private By YearField => By.XPath("(//input[@class='govuk-input govuk-date-input__input govuk-input--width-4 '])[1]");

        public WhoIsInControlOfYourOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfrimWhosInControlPage EnterWhoIsInControlDetailsAndContinue()
        {
            formCompletionHelper.EnterText(FullNameField, applydataHelpers.FullName);
            var dobcalc = applydataHelpers.Dob(2);
            formCompletionHelper.EnterText(MonthField, dobcalc.Month);
            formCompletionHelper.EnterText(YearField, dobcalc.Year);
            Continue();
            return new ConfrimWhosInControlPage(_context);
        }

    }
}


