using OpenQA.Selenium;
using SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public abstract class EarlyConnectBasePage : VerifyBasePage
    {
        #region Helpers and Context
        protected readonly EarlyConnectDataHelper earlyConnectDataHelper;
        #endregion
        public EarlyConnectBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            earlyConnectDataHelper = context.Get<EarlyConnectDataHelper>();
            if (verifypage) { VerifyPage(); }
        }

    }
}
