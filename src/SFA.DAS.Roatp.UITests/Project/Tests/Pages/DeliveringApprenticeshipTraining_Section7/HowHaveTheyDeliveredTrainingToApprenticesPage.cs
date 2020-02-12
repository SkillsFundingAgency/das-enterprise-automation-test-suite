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

        private By OnTheJob => By.CssSelector("input[value='On the job']");

        public HowHaveTheyDeliveredTrainingToApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public YourSectorsAndEmployeesPage EnterDetails()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(OnTheJob));
            SelectRadioOptionByText("No experience");
            SelectRadioOptionByText("No training delivered");
            Continue();
            return new YourSectorsAndEmployeesPage(_context);
        }
    }
}