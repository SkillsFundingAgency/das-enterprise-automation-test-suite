using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
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
        private readonly ScenarioContext _context;
        #endregion

        private By AddAnApprenticeButton => By.ClassName("button-secondary");

        private By ApprenticeUlnField => By.CssSelector("tbody tr td:nth-of-type(2)");

        private By EditApprenticeLink => By.LinkText("Edit");

        private By ContinueToApprovalButton => By.ClassName("finishEditingBtn");

        private By SaveAndContinueButton => By.ClassName("finishEditingBtn");

        protected override By TotalApprentices => By.CssSelector(".providerList tbody tr");

        public ProviderReviewYourCohortPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }
        internal ProviderAddApprenticeDetailsPage SelectAddAnApprentice()
        {
            _formCompletionHelper.ClickElement(AddAnApprenticeButton);
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
    }
}
