using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApproveApprenticeDetailsPage : ReviewYourCohort
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        protected override string PageTitle => _pageTitle;

        #region Helpers and Context
        private readonly string _pageTitle;
        #endregion

        private By ApproveMessage => By.CssSelector("#approve-details");
		private By ReviewMessage => By.CssSelector("#send-details");
		private By SaveSubmit => By.CssSelector("#main-content .govuk-button");
        private By AddAnotherApprenticeLink => By.LinkText("Add another apprentice");

        public ApproveApprenticeDetailsPage(ScenarioContext context) : base(context, false)
        {
            var noOfApprentice = TotalNoOfApprentices();
	        _pageTitle = noOfApprentice == 1 ? "Approve apprentice details" : $"Approve {noOfApprentice} apprentices' details";
            VerifyPage();
        }

        public EditApprenticeDetailsPage SelectEditApprentice(int apprenticeNumber = 0)
        {
            var editApprenticeLinks = TotalNoOfEditableApprentices();
            formCompletionHelper.ClickElement(editApprenticeLinks[apprenticeNumber]);
			return new EditApprenticeDetailsPage(context);
        }

        public SelectStandardPage SelectAddAnotherApprentice()
        {
            AddAnApprentice();
            return new SelectStandardPage(context);
        }

        public ChooseAReservationPage SelectAddAnApprenticeUsingReservation()
        {
            AddAnApprentice();
            return new ChooseAReservationPage(context);
        }

        public ApprenticeRequestsPage SaveAndExit()
        {
            formCompletionHelper.ClickLinkByText("Save and exit");
            return new ApprenticeRequestsPage(context);
        }

		public ApprenticeDetailsApprovedAndSentToTrainingProviderPage EmployerFirstApproveAndNotifyTrainingProvider()
		{
			SelectRadioOptionByForAttribute("radio-approve");
			formCompletionHelper.EnterText(ApproveMessage, apprenticeDataHelper.MessageToProvider);
			formCompletionHelper.Click(SaveSubmit);
			return new ApprenticeDetailsApprovedAndSentToTrainingProviderPage(context);
		}

		public NotificationSentToTrainingProviderPage EmployerSendsToTrainingProviderForReview()
        {
            SelectRadioOptionByForAttribute("radio-send");
			formCompletionHelper.EnterText(ReviewMessage, apprenticeDataHelper.MessageToProvider);
            formCompletionHelper.Click(SaveSubmit);
            return new NotificationSentToTrainingProviderPage(context);
        }

		public ApprenticeDetailsApprovedPage EmployerDoesSecondApproval()
        {
            SelectRadioOptionByForAttribute("radio-approve");
            formCompletionHelper.Click(SaveSubmit);
            return new ApprenticeDetailsApprovedPage(context);
        }

        public ConfirmCohortDeletionPage SelectDeleteThisGroup()
        {
            formCompletionHelper.ClickLinkByText("Delete this group");
            return new ConfirmCohortDeletionPage(context);
        }

        private void AddAnApprentice() => formCompletionHelper.ClickLinkByText("Add another apprentice");

        public ApproveApprenticeDetailsPage IsAddApprenticeLinkDisplayed()
        {
            if (pageInteractionHelper.IsElementDisplayed(AddAnotherApprenticeLink))
                throw new Exception("Link is still available to add another apprentice record");
            else
                return this;
        }
    }
}
