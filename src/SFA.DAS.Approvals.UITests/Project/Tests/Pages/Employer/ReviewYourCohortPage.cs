using System;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ReviewYourCohortPage : ReviewYourCohort
    {
        protected override string PageTitle => _pageTitle;

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly string _pageTitle;
        #endregion

        private By ApproveMessage => By.CssSelector("#approve-details");
		private By ReviewMessage => By.CssSelector("#send-details");
		private By SaveSubmit => By.CssSelector(".govuk-button");


        public ReviewYourCohortPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            var noOfApprentice = TotalNoOfApprentices();
	    _pageTitle = noOfApprentice == 1 ? "Approve apprentice details" : $"Approve {noOfApprentice} apprentices' details";
            //_pageTitle = noOfApprentice == 1 ? "Approve apprentice details" : $"Apprentice details ready for review";
            VerifyPage();
        }

        public EditApprenticePage NavigateToApprenticeDetailsAndSelectEditApprentice(int apprenticeNumber = 0)
        {
            var apprenticeDetailsLinks = GetTotalNoOfApprenticesReadyForReview();
            _formCompletionHelper.ClickElement(apprenticeDetailsLinks[apprenticeNumber]);
            
            var editApprenticeLinks = TotalNoOfEditableApprentices();
            _formCompletionHelper.ClickElement(editApprenticeLinks[apprenticeNumber]);
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

        public YourCohortRequestsPage SaveAndExit()
        {
            _formCompletionHelper.ClickLinkByText("Save and exit");
            return new YourCohortRequestsPage(_context);
        }

		public ApprenticeDetailsApprovedAndSentToTrainingProviderPage EmployerFirstApproveAndNotifyTrainingProvider()
		{
			SelectRadioOptionByForAttribute("radio-approve");
			_formCompletionHelper.EnterText(ApproveMessage, _dataHelper.MessageToProvider);
			_formCompletionHelper.Click(SaveSubmit);
			return new ApprenticeDetailsApprovedAndSentToTrainingProviderPage(_context);
		}

		public NotificationSentToTrainingProviderPage EmployerSendsToTrainingProviderForReview()
        {
            SelectRadioOptionByForAttribute("radio-send");
			_formCompletionHelper.EnterText(ReviewMessage, _dataHelper.MessageToProvider);
            _formCompletionHelper.Click(SaveSubmit);
            return new NotificationSentToTrainingProviderPage(_context);
        }

		public ApprenticeDetailsApprovedPage EmployerDoesSecondApproval()
        {
            SelectRadioOptionByForAttribute("radio-approve");
            _formCompletionHelper.Click(SaveSubmit);
            return new ApprenticeDetailsApprovedPage(_context);
        }

        public ConfirmCohortDeletionPage SelectDeleteThisGroup()
        {
            _formCompletionHelper.ClickLinkByText("Delete this group");
            return new ConfirmCohortDeletionPage(_context);
        }

        private void ClickElement(By locator)
        {
            _formCompletionHelper.ClickElement(locator);
        }

        private void Edit(int apprenticeNumber)
        {
            var editApprenticeLinks = TotalNoOfEditableApprentices();
            _formCompletionHelper.ClickElement(editApprenticeLinks[apprenticeNumber]);
        }

        private void AddAnApprentice() => _formCompletionHelper.ClickLinkByText("Add another apprentice");
    }
}
