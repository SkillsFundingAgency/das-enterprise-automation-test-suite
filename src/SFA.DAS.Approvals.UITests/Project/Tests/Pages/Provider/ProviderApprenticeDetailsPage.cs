using System;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => _dataHelper.ApprenticeFullName;

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        #endregion

        private By ViewChangesLink => By.LinkText("View changes");
        private By ReviewChangesLink => By.LinkText("Review changes");
        private By EditApprenticeDetailsLink => By.LinkText("Edit apprentice");
        private By ViewIlrMismatchDetailsLink => By.LinkText("View details");
        private By ChangeRequestMessage => By.ClassName("heading-medium");
        private By Name => By.Id("apprentice-name");
        private By DateOfBirth => By.Id("apprentice-dob");
        private By Reference => By.Id("apprentice-reference");

        public ProviderApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ProviderReviewChangesPage ClickReviewChanges()
        {
            _formCompletionHelper.ClickElement(ReviewChangesLink);
            return new ProviderReviewChangesPage(_context);
        }

        public ProviderEditApprenticePage ClickEditApprenticeDetailsLink()
        {
            _formCompletionHelper.ClickElement(EditApprenticeDetailsLink);
            return new ProviderEditApprenticePage(_context);
        }

        public ProviderDetailsOfILRDataMismatchPage ClickViewIlrMismatchDetails()
        {
            _formCompletionHelper.ClickElement(ViewIlrMismatchDetailsLink);
            return new ProviderDetailsOfILRDataMismatchPage(_context);
        }

        public void ConfirmChangeRequestPendingMessage()
        {
            string confirmationMessgage = _pageInteractionHelper.GetText(ChangeRequestMessage);
            _pageInteractionHelper.VerifyText(confirmationMessgage, "Change request");
        }

        public void ConfirmNameDOBAndReferenceChanged(string expectedName, DateTime expectedDateOfBirth, string expectedReference)
        {
            var actualName = _pageInteractionHelper.GetText(Name);
            var actualDateOfBirth = DateTime.Parse(_pageInteractionHelper.GetText(DateOfBirth));
            var actualReference = _pageInteractionHelper.GetText(Reference);

            _pageInteractionHelper.VerifyText(actualName, expectedName);
            _pageInteractionHelper.VerifyText(actualDateOfBirth.ToString(), expectedDateOfBirth.ToString());
            _pageInteractionHelper.VerifyText(actualReference, expectedReference.ToString());

        }
    }
}
