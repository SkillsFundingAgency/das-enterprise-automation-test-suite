using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TransferMatching.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
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
        protected readonly RegexHelper regexHelper;
        protected readonly TMDataHelper tMDataHelper;
        protected readonly TableRowHelper tableRowHelper;
        #endregion

        private By NonDefaultSelector => By.CssSelector(".govuk-checkboxes .govuk-checkboxes__item");

        protected TransferMatchingBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            regexHelper = context.Get<RegexHelper>();
            tMDataHelper = context.Get<TMDataHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }

        protected CreateATransferPledgePage SelectAndContinue()
        {
            formCompletionHelper.ClickElement(() => tMDataHelper.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(NonDefaultSelector)));
            Continue();
            return new CreateATransferPledgePage(_context);
        }

    }
}