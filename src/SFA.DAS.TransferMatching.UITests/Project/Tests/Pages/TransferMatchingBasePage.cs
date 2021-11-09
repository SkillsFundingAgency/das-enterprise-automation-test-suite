using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TransferMatching.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public abstract class TransferMatchingBasePage : BasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        protected readonly TMDataHelper tMDataHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly ApprenticeDataHelper datahelper;
        #endregion

        private By NonDefaultSelector => By.CssSelector(".govuk-checkboxes .govuk-checkboxes__input");

        protected By ErrorMessageSelector => By.CssSelector(".govuk-error-summary");

        protected TransferMatchingBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            tMDataHelper = context.Get<TMDataHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            datahelper = context.Get<ApprenticeDataHelper>();
            VerifyPage();
        }

        public string GetErrorMessage() => pageInteractionHelper.GetText(ErrorMessageSelector);

        protected CreateATransferPledgePage SelectAndContinue()
        {
            SelectRandomCheckbox();

            Continue();

            return new CreateATransferPledgePage(_context);
        }

        protected void SelectRandomCheckbox()
        {
            var NonDefaultList = pageInteractionHelper.FindElements(NonDefaultSelector);

            int randomvalue = tMDataHelper.GenerateRandomNumberLessThanMaxAmount(NonDefaultList.Count);

            formCompletionHelper.ClickElement(NonDefaultList.ElementAt(randomvalue));
        }
    }
}