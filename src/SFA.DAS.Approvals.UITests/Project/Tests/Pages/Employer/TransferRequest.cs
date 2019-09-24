using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public abstract class TransferRequest : BasePage
    {
        public TransferRequest(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }

        protected override By PageHeader => By.Id("transfer-confirmation");
    }
}