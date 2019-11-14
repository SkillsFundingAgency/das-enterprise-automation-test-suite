using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderReviewYourCohortPage : ReviewYourCohort
    {
        protected override string PageTitle => "Review your cohort";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
		private readonly PageInteractionHelper _pageInteractionHelper;
		private readonly ScenarioContext _context;
		#endregion

		private By pireanPreprodButton = By.XPath("//span[contains(text(),'Pirean Preprod')]");

		private By AddAnApprenticeButton => By.ClassName("button-secondary");

        private By ApprenticeUlnField => By.CssSelector("tbody tr td:nth-of-type(2)");

        private By EditApprenticeLink => By.LinkText("Edit");

        private By ContinueToApprovalButton => By.ClassName("finishEditingBtn");

        private By SaveAndContinueButton => By.ClassName("finishEditingBtn");

        protected override By TotalApprentices => By.CssSelector(".providerList tbody tr");

        private By DeleteCohortbutton => By.ClassName("delete-button");

		public ProviderReviewYourCohortPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
			_pageInteractionHelper = context.Get<PageInteractionHelper>();
			VerifyPage();
        }

        internal ProviderChooseAReservationPage SelectAddAnApprenticeUsingReservation()
        {
            _formCompletionHelper.ClickElement(AddAnApprenticeButton);
            return new ProviderChooseAReservationPage(_context);
        }

        internal ProviderAddApprenticeDetailsPage SelectAddAnApprentice()
        {
            _formCompletionHelper.ClickElement(AddAnApprenticeButton);
			if (_pageInteractionHelper.IsElementDisplayed(pireanPreprodButton))
			{
				_formCompletionHelper.ClickElement(pireanPreprodButton);
			}
			return new ProviderAddApprenticeDetailsPage(_context);
        }

        public List<IWebElement> ApprenticeUlns()
        {
            return pageInteractionHelper.FindElements(ApprenticeUlnField);
        }

        public ProviderEditApprenticeDetailsPage SelectEditApprentice(int apprenticeNumber = 0)
        {
            IList<IWebElement> editApprenticeLinks = pageInteractionHelper.FindElements(EditApprenticeLink);
			_formCompletionHelper.ClickElement(editApprenticeLinks[apprenticeNumber]);
			if (_pageInteractionHelper.IsElementDisplayed(pireanPreprodButton))
			{
				_formCompletionHelper.ClickElement(pireanPreprodButton);
			}
			return new ProviderEditApprenticeDetailsPage(_context);
        }

        public ProviderChooseAnOptionPage SelectContinueToApproval()
        {
            _formCompletionHelper.ClickElement(ContinueToApprovalButton);
            return new ProviderChooseAnOptionPage(_context);
        }

        public ProviderChooseAnOptionPage SelectSaveAndContinue()
        {
            _formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderChooseAnOptionPage(_context);
        }

        public ProviderConfirmCohortDeletionPage SelectDeleteCohort()
        {
            _formCompletionHelper.ClickElement(DeleteCohortbutton);
            return new ProviderConfirmCohortDeletionPage(_context);
        }

    }
}
