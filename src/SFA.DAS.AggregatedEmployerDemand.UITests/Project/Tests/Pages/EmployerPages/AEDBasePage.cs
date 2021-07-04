using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages
{
    public abstract class AEDBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        private readonly ScenarioContext _context;
        protected readonly ProviderConfig providerConfig;

        #endregion

        private new By Continue => By.Id("continue");
        protected virtual By FirstCheckbox => By.ClassName("govuk-checkboxes__input");


        protected AEDBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            providerConfig = context.GetProviderConfig<ProviderConfig>();
            VerifyPage();
        }

        protected void ContinueToNextPage() => formCompletionHelper.Click(Continue);
    }
}
