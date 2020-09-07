using NUnit.Framework;
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
        private By ApprenticeshipStatus => By.CssSelector("#app-status tbody tr td");
        private By StatusDateTitle => By.CssSelector("#app-status tbody tr:nth-child(2) th");
        private By CompletionDate => By.Id("completionDate");

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

        public void ValidateCompletionStatus()
        {
            string expectedCompletionDate = DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year; 
           
            Assert.AreEqual(pageInteractionHelper.GetText(ApprenticeshipStatus), "Completed", "Validate Status of the apprenticeship");
            Assert.AreEqual(pageInteractionHelper.GetText(StatusDateTitle), "Completion payment month", "Validate Completion Date Title");
            Assert.AreEqual(pageInteractionHelper.GetText(CompletionDate), expectedCompletionDate, "Validate Completion Date");
        }

        public void ValidateEditLinksDoNotExist()
        {
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(EditApprenticeStatusLink));
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(EditApprenticeDetailsLink));
        }
    }
}