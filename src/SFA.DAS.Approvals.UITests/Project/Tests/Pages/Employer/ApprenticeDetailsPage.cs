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
        private By EditStopDateLink => By.LinkText("Edit");//By.Id("editStopDateLink");
        private By EditEndDateLink => By.Id("editEndDateLink"); 
        private By EditApprenticeDetailsLink => By.CssSelector("a.float-right");
        private By ApprenticeshipStatus => By.CssSelector("#app-status tbody tr td");
        private By StatusDateTitle => By.CssSelector("#app-status tbody tr:nth-child(2) th");
        private By CompletionDate => By.Id("completionDate");
        private By changeTrainingProviderLink => By.Id("changeTrainingProviderLink");

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

        public string GetApprenticeshipStatus() => pageInteractionHelper.GetText(ApprenticeshipStatus);
        public string GetStatusDateTitle() => pageInteractionHelper.GetText(StatusDateTitle);
        public string GetCompletionDate() => pageInteractionHelper.GetText(CompletionDate);
        public bool IsEditApprenticeStatusLinkVisible() => pageInteractionHelper.IsElementDisplayed(EditApprenticeStatusLink);
        public bool IsEditApprenticeDetailsLinkVisible() => pageInteractionHelper.IsElementDisplayed(EditApprenticeDetailsLink);
        public bool IsEditEndDateLinkVisible() => pageInteractionHelper.IsElementDisplayed(EditEndDateLink);
        public ChangingTrainingProviderPage ClickOnChangeOfProviderLink()
        {
            formCompletionHelper.ClickElement(changeTrainingProviderLink);
            return new ChangingTrainingProviderPage(_context);
        } 


    }
}