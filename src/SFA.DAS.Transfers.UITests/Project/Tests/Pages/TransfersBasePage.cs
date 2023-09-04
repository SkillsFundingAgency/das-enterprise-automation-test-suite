using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public abstract class TransfersBasePage : VerifyBasePage
    {
        protected TransfersBasePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}