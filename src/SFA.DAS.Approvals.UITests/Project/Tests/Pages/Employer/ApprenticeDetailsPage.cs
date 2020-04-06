using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => _dataHelper.ApprenticeFullName;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By ViewChangesLink => By.LinkText("View changes");
        private By ReviewChangesLink => By.LinkText("Review changes");
        private By EditApprenticeStatusLink => By.LinkText("Edit status");
        private By EditStopDateLink => By.Id("editStopDateLink");
        private By EditApprenticeDetailsLink => By.LinkText("Edit");
        
        public ApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public EditApprenticePage ClickEditApprenticeDetailsLink()
        {
            _formCompletionHelper.ClickElement(EditApprenticeDetailsLink);
            return new EditApprenticePage(_context);
        }

        public ReviewChangesPage ClickReviewChanges()
        {
            _formCompletionHelper.ClickElement(ReviewChangesLink);
            return new ReviewChangesPage(_context);
        }

        public ChangeApprenticeStatusPage ClickEditStatusLink()
        {
            _formCompletionHelper.ClickElement(EditApprenticeStatusLink);
            return new ChangeApprenticeStatusPage(_context);
        }

        public ThisApprenticeshipTrainingStopPage ClickEditStopDateLink()
        {
            _formCompletionHelper.ClickElement(EditStopDateLink);
            return new ThisApprenticeshipTrainingStopPage(_context);
        }

        public bool VerifyIfChangeRequestWasApproved()
        {
            if (_pageInteractionHelper.IsElementDisplayed(ViewChangesLink))
                throw new Exception("Change request was not approved");
            else
                return true;
        }
    }
}