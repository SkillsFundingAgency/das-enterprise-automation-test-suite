using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderReviewYourCohortPage : BasePage
    {
        protected override string PageTitle => "Review your cohort";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly TableRowHelper _tableRowHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        private By TotalApprentices => By.CssSelector(".providerList tbody tr");

        private By ApprenticeUlnField => By.CssSelector("tbody tr td:nth-of-type(2)");

        private By EditApprenticeLink => By.LinkText("Edit");

        private By PireanPreprodButton => By.XPath("//span[contains(text(),'Pirean Preprod')]");

        private By ContinueToApprovalButton => By.ClassName("finishEditingBtn");

        public ProviderReviewYourCohortPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }

        public int TotalNoOfApprentices()
        {
            return _pageInteractionHelper.FindElements(TotalApprentices).Count;
        }

        public List<IWebElement> ApprenticeUlns()
        {
            return _pageInteractionHelper.FindElements(ApprenticeUlnField);
        }

        public ProviderEditApprenticeDetailsPage SelectEditApprentice(int apprenticeNumber = 0)
        {
            IList<IWebElement> editApprenticeLinks = _pageInteractionHelper.FindElements(EditApprenticeLink);
            _formCompletionHelper.ClickElement(editApprenticeLinks[apprenticeNumber]);
            if (_pageInteractionHelper.IsElementDisplayed(PireanPreprodButton))
            {
                _formCompletionHelper.ClickElement(PireanPreprodButton);
            }
            return new ProviderEditApprenticeDetailsPage(_context);
        }

        public ProviderChooseAnOptionPage SelectContinueToApproval()
        {
            _formCompletionHelper.ClickElement(ContinueToApprovalButton);
            return new ProviderChooseAnOptionPage(_context);
        }
    }
}
