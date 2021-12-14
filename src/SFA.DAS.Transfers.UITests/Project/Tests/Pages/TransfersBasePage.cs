using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public abstract class TransfersBasePage : VerifyBasePage
    {
        #region Helpers and Context
        protected readonly TransfersUser transfersUser;
        #endregion

        protected TransfersBasePage(ScenarioContext context) : base(context)
        {
            transfersUser = context.GetUser<TransfersUser>();
            VerifyPage();
        }
    }
}