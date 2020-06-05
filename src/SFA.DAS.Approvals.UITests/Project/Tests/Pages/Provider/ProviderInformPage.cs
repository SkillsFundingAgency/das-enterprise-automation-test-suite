using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderInformPage : ApprovalsBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ChangeTheEmployerButton => By.Id("change-the-employer-button");

        public ProviderInformPage(ScenarioContext context) : base(context) => _context = context;

        protected override string PageTitle => "What you'll need";

        public ChangeOfEmployerSelectEmployerPage SelectChangeTheEmployer()
        {
            formCompletionHelper.Click(ChangeTheEmployerButton);
            return new ChangeOfEmployerSelectEmployerPage(_context);
        }
    }
}
