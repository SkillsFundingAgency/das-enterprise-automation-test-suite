using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => apprenticeDataHelper.ApprenticeFullName;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ViewChangesLink => By.LinkText("View changes");
        private By ReviewChangesLink => By.LinkText("Review changes");
        private By EditApprenticeStatusLink => By.LinkText("Edit status");
        private By EditStopDateLink => By.Id("editStopDateLink");
        private By EditApprenticeDetailsLink => By.LinkText("Edit");
        
        public ApprenticeDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public EditApprenticePage ClickEditApprenticeDetailsLink()
        {
            formCompletionHelper.ClickElement(EditApprenticeDetailsLink);
            return new EditApprenticePage(_context);
        }

        public ReviewChangesPage ClickReviewChanges()
        {
            formCompletionHelper.ClickElement(ReviewChangesLink);
            return new ReviewChangesPage(_context);
        }

        public ChangeApprenticeStatusPage ClickEditStatusLink()
        {
            formCompletionHelper.ClickElement(EditApprenticeStatusLink);
            return new ChangeApprenticeStatusPage(_context);
        }

        public ThisApprenticeshipTrainingStopPage ClickEditStopDateLink()
        {
            formCompletionHelper.ClickElement(EditStopDateLink);
            return new ThisApprenticeshipTrainingStopPage(_context);
        }

        public bool VerifyIfChangeRequestWasApproved()
        {
            if (pageInteractionHelper.IsElementDisplayed(ViewChangesLink))
                throw new Exception("Change request was not approved");
            else
                return true;
        }
    }
}