using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public abstract class TransferRequest : ApprovalsBasePage
    {
        public TransferRequest(ScenarioContext context) : base(context) { }

        protected override By PageHeader => By.Id("transfer-confirmation");
    }
}