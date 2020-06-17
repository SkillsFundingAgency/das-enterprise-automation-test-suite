using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class FinancialHealthEvaluationPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Financial health evaluation";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By DayLabel => By.CssSelector("label[for='GoodFinancialDueDate.Day']");
        private By MonthLabel => By.CssSelector("label[for='GoodFinancialDueDate.Month']");
        private By YearLabel => By.CssSelector("label[for='GoodFinancialDueDate.Year']");
        private By ParentElement => By.XPath("..");
        private By InputElement => By.CssSelector("input");

        public FinancialHealthEvaluationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EvaluationSubmittedPage SelectGoodAndContinue()
        {
            SelectRadioOptionByText("Good");
            var duedate = ePAOAdminDataHelper.FinancialAssesmentDueDate;
            formCompletionHelper.EnterText(FindInputElement(DayLabel), duedate.Day.ToString());
            formCompletionHelper.EnterText(FindInputElement(MonthLabel), duedate.Month.ToString());
            formCompletionHelper.EnterText(FindInputElement(YearLabel), duedate.Year.ToString());
            Continue();
            return new EvaluationSubmittedPage(_context);
        }

        private IWebElement FindInputElement(By @by) => pageInteractionHelper.FindElement(@by).FindElement(ParentElement).FindElement(InputElement);
    }
}

