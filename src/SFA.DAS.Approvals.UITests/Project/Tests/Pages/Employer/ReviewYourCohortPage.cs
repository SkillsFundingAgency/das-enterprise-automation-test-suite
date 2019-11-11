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
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly string _pageTitle;
        #endregion

        private By RadioOptions => By.CssSelector(".govuk-radios__label");
        private By ApproveMessageToProvider => By.CssSelector("#approve-details");
        private By ReviewMessageToProvider => By.CssSelector("#send-details");
        private By SaveSubmit => By.CssSelector(".govuk-button");


        public ReviewYourCohortPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            var noOfApprentice = TotalNoOfApprentices();
            _pageTitle = noOfApprentice == 1 ? "Approve apprentice details" : $"Approve {noOfApprentice} apprentices' details";
            VerifyPage();
        }

        public EditApprenticePage SelectEditApprentice(int apprenticeNumber = 0)
        {
            Edit(apprenticeNumber);
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

        public ApprenticeDetailsApprovedAndSentToTrainingProviderPage Approve()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioOptions, "radio-approve");
            _formCompletionHelper.EnterText(ApproveMessageToProvider, _dataHelper.MessageToProvider);
            _formCompletionHelper.Click(SaveSubmit);
            return new ApprenticeDetailsApprovedAndSentToTrainingProviderPage(_context);
        }

        public NotificationSentToTrainingProviderPage SentToTrainingProvider()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioOptions, "radio-send");
            _formCompletionHelper.EnterText(ReviewMessageToProvider, _dataHelper.MessageToProvider);
            _formCompletionHelper.Click(SaveSubmit);
            return new NotificationSentToTrainingProviderPage(_context);
        }

        public ConfirmCohortDeletionPage SelectDeleteCohort()
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