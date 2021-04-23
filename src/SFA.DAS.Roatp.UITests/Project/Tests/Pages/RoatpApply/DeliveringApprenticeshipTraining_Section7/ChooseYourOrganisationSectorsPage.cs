using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class ChooseYourOrganisationSectorsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What sectors will your organisation deliver apprenticeship training in?";

        protected override By PageHeader => By.CssSelector(".govuk-label");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ChooseYourOrganisationSectorsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public YourSectorsAndEmployeesPage SelectSectors(string sector)
        {
            SelectCheckBoxByText(sector);
            Continue();
            return new YourSectorsAndEmployeesPage(_context);
        }
    }
}