using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages
{
    public abstract class AEDBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        //private readonly ScenarioContext _context;
        #endregion

        //private By ContinueButton => By.Id("continue");

        protected AEDBasePage(ScenarioContext context) : base(context)
        {
            //_context = context;
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }

        protected void ContinueToNextPage() => formCompletionHelper.Click(ContinueButton);
    }
}
