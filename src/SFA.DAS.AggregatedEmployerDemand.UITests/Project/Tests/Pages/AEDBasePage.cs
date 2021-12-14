using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages
{
    public abstract class AEDBasePage : VerifyBasePage
    {
        #region Helpers and Context
        protected readonly ProviderConfig providerConfig;
        #endregion

        private new By Continue => By.Id("continue");

        protected AEDBasePage(ScenarioContext context) : base(context)
        {
            providerConfig = context.GetProviderConfig<ProviderConfig>();
            VerifyPage();
        }

        protected void ContinueToNextPage() => formCompletionHelper.Click(Continue);
    }
}
