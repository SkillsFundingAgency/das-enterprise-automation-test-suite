using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ChangeStatusPage : ChangeBasePage
    {
        protected override string PageTitle => $"Change status for {objectContext.GetProviderName()}";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ActiveStatus => By.CssSelector("label[for='status-1']");

        private By ActiveButNoApprenticeStatus => By.CssSelector("label[for='status-1']");

        protected override By ContinueButton => By.CssSelector(".govuk-button[value='Change']");

        public ChangeStatusPage(ScenarioContext context) : base(context) => _context = context;

        public ResultsFoundPage ChangeStatusToActive() => ChangeStatus(ActiveStatus);

        public ResultsFoundPage ChangeStatusToActiveButNoApprentice() => ChangeStatus(ActiveButNoApprenticeStatus);

        private ResultsFoundPage ChangeStatus(By by)
        {
            formCompletionHelper.ClickElement(by);
            Continue();
            return new ResultsFoundPage(_context);
        }
    }
}