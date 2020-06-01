using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
   public class WillTheApprenticeshipTrainingStartInTheNextSixMonthsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Will the apprenticeship training start in the next 6 months?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ClickYesContinue => By.Id("will-apprenticeship-training-start-button");

        public WillTheApprenticeshipTrainingStartInTheNextSixMonthsPage(ScenarioContext context) : base(context) => _context = context;

        public AreYouSettingUpAnApprenticeshipForAnExistingEmployeePage YesWillTrainingStartInSixMonths()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            formCompletionHelper.Click(ClickYesContinue);
            return new AreYouSettingUpAnApprenticeshipForAnExistingEmployeePage(_context);
        }
    }
}
