using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ReviewYourCohortPage : ReviewYourCohort
    {
        protected override string PageTitle => _pageTitle;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly string _pageTitle;
        #endregion

        private By ApproveMessage => By.CssSelector("#approve-details");
		private By ReviewMessage => By.CssSelector("#send-details");
		private By SaveSubmit => By.CssSelector("#main-content .govuk-button");
        private By AddAnotherApprenticeLink = By.LinkText("Add another apprentice");


        public ReviewYourCohortPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            var noOfApprentice = TotalNoOfApprentices();
	        _pageTitle = noOfApprentice == 1 ? "Approve apprentice details" : $"Approve {noOfApprentice} apprentices' details";
            VerifyPage();
        }

        public EditApprenticePage SelectEditApprentice(int apprenticeNumber = 0)
        {
            var editApprenticeLinks = TotalNoOfEditableApprentices();
            formCompletionHelper.ClickElement(editApprenticeLinks[apprenticeNumber]);
			return new EditApprenticePage(_context);
        }

        public AddApprenticeDetailsPage SelectAddAnApprentice()
        {
            AddAnApprentice();
            return new AddApprenticeDetailsPage(_context);
        }

        public ChooseAReservationPage SelectAddAnApprenticeUsingReservation()
        {
            AddAnApprentice();
            return new ChooseAReservationPage(_context);
        }

        public ApprenticeRequestsPage SaveAndExit()
        {
            formCompletionHelper.ClickLinkByText("Save and exit");
            return new ApprenticeRequestsPage(_context);
        }

		public ApprenticeDetailsApprovedAndSentToTrainingProviderPage EmployerFirstApproveAndNotifyTrainingProvider()
		{
			SelectRadioOptionByForAttribute("radio-approve");
			formCompletionHelper.EnterText(ApproveMessage, apprenticeDataHelper.MessageToProvider);
			formCompletionHelper.Click(SaveSubmit);
			return new ApprenticeDetailsApprovedAndSentToTrainingProviderPage(_context);
		}

		public NotificationSentToTrainingProviderPage EmployerSendsToTrainingProviderForReview()
        {
            SelectRadioOptionByForAttribute("radio-send");
			formCompletionHelper.EnterText(ReviewMessage, apprenticeDataHelper.MessageToProvider);
            formCompletionHelper.Click(SaveSubmit);
            return new NotificationSentToTrainingProviderPage(_context);
        }

		public ApprenticeDetailsApprovedPage EmployerDoesSecondApproval()
        {
            SelectRadioOptionByForAttribute("radio-approve");
            formCompletionHelper.Click(SaveSubmit);
            return new ApprenticeDetailsApprovedPage(_context);
        }

        public ConfirmCohortDeletionPage SelectDeleteThisGroup()
        {
            formCompletionHelper.ClickLinkByText("Delete this group");
            return new ConfirmCohortDeletionPage(_context);
        }

        private void AddAnApprentice() => formCompletionHelper.ClickLinkByText("Add another apprentice");

        public ReviewYourCohortPage IsAddApprenticeLinkDisplayed()
        {
            if (pageInteractionHelper.IsElementDisplayed(AddAnotherApprenticeLink))
                throw new Exception("Link is still available to add another apprentice record");
            else
                return this;
        }
    }
}
