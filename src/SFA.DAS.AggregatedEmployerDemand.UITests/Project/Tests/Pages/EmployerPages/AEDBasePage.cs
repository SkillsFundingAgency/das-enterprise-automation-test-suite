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
        protected readonly IFrameHelper frameHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        protected readonly ProviderConfig providerConfig;
        #endregion

        private new By Continue => By.Id("continue");
        protected virtual By FirstCheckbox => By.ClassName("govuk-checkboxes__input");


        protected AEDBasePage(ScenarioContext context) : base(context)
        {
            frameHelper = context.Get<IFrameHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            providerConfig = context.GetProviderConfig<ProviderConfig>();
            VerifyPage();
        }

        protected void ContinueToNextPage() => formCompletionHelper.Click(Continue);
    }
}
