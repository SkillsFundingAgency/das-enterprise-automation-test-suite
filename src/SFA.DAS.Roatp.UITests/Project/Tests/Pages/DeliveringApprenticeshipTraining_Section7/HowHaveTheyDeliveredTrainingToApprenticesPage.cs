using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class HowHaveTheyDeliveredTrainingToApprenticesPage : RoatpBasePage
    {
        protected override string PageTitle => "How have they delivered training to apprentices";

        protected override By PageHeader => By.CssSelector(".govuk-heading-3");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public HowHaveTheyDeliveredTrainingToApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public YourSectorsAndEmployeesPage EnterDetails()
        {
            SelectCheckboxByText("On the job");
            SelectRadioOptionByText("No experience");
            SelectRadioOptionByText("No training delivered");
            Continue();
            return new YourSectorsAndEmployeesPage(_context);
        }

    }
}


