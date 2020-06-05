using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderReviewYourCohortPage : ReviewYourCohort
    {
        protected override string PageTitle => "Review your cohort";

        #region Helpers and Context
		private readonly ScenarioContext _context;
		#endregion

		private By PireanPreprodButton => By.XPath("//span[contains(text(),'Pirean Preprod')]");

		private By AddAnApprenticeButton => By.ClassName("button-secondary");

        private By ApprenticeUlnField => By.CssSelector("tbody tr td:nth-of-type(2)");

        private By EditApprenticeLink => By.LinkText("Edit");

        private By ContinueToApprovalButton => By.ClassName("finishEditingBtn");

        private By SaveAndContinueButton => By.ClassName("finishEditingBtn");

        protected override By TotalApprentices => By.CssSelector(".providerList tbody tr");

        private By DeleteCohortbutton => By.ClassName("delete-button");

		public ProviderReviewYourCohortPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderChooseAReservationPage SelectAddAnApprenticeUsingReservation()
        {
            formCompletionHelper.ClickElement(AddAnApprenticeButton);
            return new ProviderChooseAReservationPage(_context);
        }

        internal ProviderAddApprenticeDetailsPage SelectAddAnApprentice()
        {
            formCompletionHelper.ClickElement(AddAnApprenticeButton);
			if (pageInteractionHelper.IsElementDisplayed(PireanPreprodButton))
			{
				formCompletionHelper.ClickElement(PireanPreprodButton);
			}
			return new ProviderAddApprenticeDetailsPage(_context);
        }

        public List<IWebElement> ApprenticeUlns()
        {
            return base.pageInteractionHelper.FindElements(ApprenticeUlnField);
        }

        public ProviderEditApprenticeDetailsPage SelectEditApprentice(int apprenticeNumber = 0)
        {
            IList<IWebElement> editApprenticeLinks = base.pageInteractionHelper.FindElements(EditApprenticeLink);
			formCompletionHelper.ClickElement(editApprenticeLinks[apprenticeNumber]);
			if (pageInteractionHelper.IsElementDisplayed(PireanPreprodButton))
			{
				formCompletionHelper.ClickElement(PireanPreprodButton);
			}
			return new ProviderEditApprenticeDetailsPage(_context);
        }

        public ProviderChooseAnOptionPage SelectContinueToApproval()
        {
            formCompletionHelper.ClickElement(ContinueToApprovalButton);
            return new ProviderChooseAnOptionPage(_context);
        }

        public ProviderChooseAnOptionPage SelectSaveAndContinue()
        {
            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderChooseAnOptionPage(_context);
        }

        public ProviderConfirmCohortDeletionPage SelectDeleteCohort()
        {
            formCompletionHelper.ClickElement(DeleteCohortbutton);
            return new ProviderConfirmCohortDeletionPage(_context);
        }
    }
}
