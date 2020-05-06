using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
   public class WillTheApprenticeshipTrainingStartInTheNextSixMonthsPage : BasePage
    {
        protected override string PageTitle => "Will the apprenticeship training start in the next 6 months?";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion
        private By ClickYesContinue = By.Id("will-apprenticeship-training-start-button");
        public WillTheApprenticeshipTrainingStartInTheNextSixMonthsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AreYouSettingUpAnApprenticeshipForAnExistingEmployeePage YesWillTrainingStartInSixMonths()
        {
            _formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            _formCompletionHelper.Click(ClickYesContinue);
            return new AreYouSettingUpAnApprenticeshipForAnExistingEmployeePage(_context);
        }
    }
}
