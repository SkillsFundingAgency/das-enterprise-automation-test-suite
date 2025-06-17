using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public abstract class TransferMatchingBasePage : VerifyBasePage
    {
        protected TransferMatchingBasePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}