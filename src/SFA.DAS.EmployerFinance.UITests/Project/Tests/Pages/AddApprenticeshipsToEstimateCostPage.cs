using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class AddApprenticeshipsToEstimateCostPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Estimate apprenticeships you could fund";

        private By ApprenticeshipCombobox => By.CssSelector(".select2-selection");

        private By ApprenticeshipInputBox => By.CssSelector(".select2-search__field");

        private By ApprenticeshipOptions => By.CssSelector(".select2-results__option");

        private By NoOfApprentice => By.CssSelector("input#no-of-app");

        private By StartDateMonth => By.CssSelector("input#startDateMonth");

        private By StartDateYear => By.CssSelector("input#startDateYear");

        private readonly ScenarioContext _context;
        public AddApprenticeshipsToEstimateCostPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public void EnterDetails()
        {
            formCompletionHelper.Click(ApprenticeshipCombobox);
            formCompletionHelper.EnterText(ApprenticeshipInputBox, "software tester");
            formCompletionHelper.Click(ApprenticeshipOptions);
            formCompletionHelper.EnterText(NoOfApprentice, 1);
            formCompletionHelper.EnterText(StartDateMonth, apprenticeCourseStartDateDataHelper.CourseStartDate.Month);
            formCompletionHelper.EnterText(StartDateYear, apprenticeCourseStartDateDataHelper.CourseStartDate.Year);
        }
    }
}
