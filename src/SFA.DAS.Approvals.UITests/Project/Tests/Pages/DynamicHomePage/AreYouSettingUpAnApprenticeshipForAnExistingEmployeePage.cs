using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class AreYouSettingUpAnApprenticeshipForAnExistingEmployeePage : BasePage
    {
        protected override string PageTitle => "Are you setting up an apprenticeship for an existing employee?";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion
        private By ClickYesContinue = By.Id("apprentice-for-existing-employee-button");
        public AreYouSettingUpAnApprenticeshipForAnExistingEmployeePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public SetUpAnApprenticeshipForAnExistingEmployeePage YesSetupForExistingEmployee()
        {
            _formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Yes");
            _formCompletionHelper.Click(ClickYesContinue);
            return new SetUpAnApprenticeshipForAnExistingEmployeePage(_context);
        }
    }
}