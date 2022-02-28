using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages
{
    public abstract class AEDBasePage : VerifyBasePage
    {
        #region Helpers and Context
        protected readonly ProviderConfig providerConfig;
        protected readonly AedDataHelper dataHelper;
        #endregion

        protected override By ContinueButton => By.CssSelector("#continue");

        protected AEDBasePage(ScenarioContext context) : base(context)
        {
            providerConfig = context.GetProviderConfig<ProviderConfig>();
            context.TryGetValue(out dataHelper);
            VerifyPage();
        }
    }
}
