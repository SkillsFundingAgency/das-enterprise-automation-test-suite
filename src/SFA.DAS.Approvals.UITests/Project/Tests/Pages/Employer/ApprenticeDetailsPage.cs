using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => _dataHelper.ApprenticeFullName;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ApprovalsDataHelper _dataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By ViewChangesLink => By.LinkText("View changes");
        private By ReviewChangesLink => By.LinkText("Review changes");
        private By EditApprenticeStatusLink => By.LinkText("Edit status");
        private By EditStopDateLink => By.Id("editStopDateLink");
        private By EditApprenticeDetailsLink => By.LinkText("Edit");

        public ApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprovalsDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        
        internal EditApprenticeDetailsPagePostApproval ClickEditApprenticeDetailsLink()
        {
            _formCompletionHelper.ClickElement(EditApprenticeDetailsLink);
            return new EditApprenticeDetailsPagePostApproval(_context);
        }
    }
}