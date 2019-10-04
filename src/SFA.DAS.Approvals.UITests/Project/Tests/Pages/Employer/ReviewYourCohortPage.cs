using System;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ReviewYourCohortPage : ReviewYourCohort
    {
        protected override string PageTitle => "Review your cohort";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By AddAnApprenticeButton => By.ClassName("button-secondary");
        private By SaveAndContinueButton => By.ClassName("finishEditingBtn");
        private By ContinueToApprovalButton => By.ClassName("finishEditingBtn");
        private By EditApprenticeLink => By.LinkText("Edit");
        private By DeleteCohortbutton => By.ClassName("delete-button");

        public ReviewYourCohortPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public int TotalNoOfEditableApprentice()
        {
            return _pageInteractionHelper.FindElements(By.LinkText("Edit")).Count;
        }

        public EditApprenticePage SelectEditApprentice(int apprenticeNumber = 0)
        {
            Edit(apprenticeNumber);
            return new EditApprenticePage(_context);
        }

        public AddApprenticeDetailsPage SelectAddAnApprentice()
        {
            ClickElement(AddAnApprenticeButton);
            return new AddApprenticeDetailsPage(_context);
        }

        public ChooseAnOptionPage SelectContinueToApproval()
        {
            ClickElement(ContinueToApprovalButton);
            return new ChooseAnOptionPage(_context);
        }

        public ChooseAnOptionPage SaveAndContinue()
        {
            ClickElement(SaveAndContinueButton);
            return new ChooseAnOptionPage(_context);
        }

        private void ClickElement(By locator)
        {
            _formCompletionHelper.ClickElement(locator, true);
        }

        private void Edit(int apprenticeNumber)
        {
            var editApprenticeLinks = _pageInteractionHelper.FindElements(EditApprenticeLink);
            _formCompletionHelper.ClickElement(editApprenticeLinks[apprenticeNumber]);
        }

        public ConfirmCohortDeletionPage SelectDeleteCohort()
        {
            _formCompletionHelper.ClickElement(DeleteCohortbutton);
            return new ConfirmCohortDeletionPage(_context);
        }
    }
}