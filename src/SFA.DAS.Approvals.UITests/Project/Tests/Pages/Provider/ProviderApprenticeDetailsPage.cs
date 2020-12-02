using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => apprenticeDataHelper.ApprenticeFullName;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ReviewChangesLink => By.LinkText("Review changes");
        private By EditApprenticeDetailsLink => By.LinkText("Edit apprentice");
        private By ViewIlrMismatchDetailsLink => By.LinkText("View details");
        private By ChangeEmployerLink => By.Id("change-employer-link");
        private By ChangeRequestMessage => By.ClassName("das-notification");
        private By Name => By.Id("apprentice-name");
        private By DateOfBirth => By.Id("apprentice-dob");
        private By Reference => By.Id("apprentice-reference");
        private By ChangeOfPartyBanner => By.Id("change-of-party-status-text");
        private By ViewChanges => By.Id("change-employer-link");

        public ProviderApprenticeDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderReviewChangesPage ClickReviewChanges()
        {
            formCompletionHelper.ClickElement(ReviewChangesLink);
            return new ProviderReviewChangesPage(_context);
        }

        public ProviderEditApprenticePage ClickEditApprenticeDetailsLink()
        {
            formCompletionHelper.ClickElement(EditApprenticeDetailsLink);
            return new ProviderEditApprenticePage(_context);
        }

        public ProviderDetailsOfILRDataMismatchPage ClickViewIlrMismatchDetails()
        {
            formCompletionHelper.ClickElement(ViewIlrMismatchDetailsLink);
            return new ProviderDetailsOfILRDataMismatchPage(_context);
        }

        public ProviderInformPage ClickChangeEmployerLink()
        {
            formCompletionHelper.Click(ChangeEmployerLink);
            return new ProviderInformPage(_context);
        }

        public void ConfirmChangeRequestPendingMessage()
        {
            string confirmationMessgage = pageInteractionHelper.GetText(ChangeRequestMessage);
            pageInteractionHelper.VerifyText(confirmationMessgage, "Change request");
        }

        public void ConfirmNameDOBAndReferenceChanged(string expectedName, DateTime expectedDateOfBirth, string expectedReference)
        {
            var actualName = pageInteractionHelper.GetText(Name);
            var actualDateOfBirth = DateTime.Parse(pageInteractionHelper.GetText(DateOfBirth));
            var actualReference = pageInteractionHelper.GetText(Reference);

            pageInteractionHelper.VerifyText(actualName, expectedName);
            pageInteractionHelper.VerifyText(actualDateOfBirth.ToString(), expectedDateOfBirth.ToString());
            pageInteractionHelper.VerifyText(actualReference, expectedReference.ToString());

        }

        public string GetCoPBanner()
        {
            return pageInteractionHelper.GetText(ChangeOfPartyBanner);
        }

        public ProviderViewChangesPage ClickViewChangesLink()
        {
            formCompletionHelper.Click(ViewChanges);
            return new ProviderViewChangesPage(_context);
        }

        public bool IsCoELinkDisplayed() => pageInteractionHelper.IsElementDisplayed(ChangeEmployerLink);
    }
}
