using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public abstract class TransferRequest : TransfersBasePage
    {
        public TransferRequest(ScenarioContext context) : base(context) { }

        protected override By PageHeader => By.Id("transfer-confirmation");
    }
}