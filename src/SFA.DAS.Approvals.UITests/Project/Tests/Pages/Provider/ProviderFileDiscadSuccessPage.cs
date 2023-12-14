using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderFileDiscadSuccessPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By ContinueButton => By.Id("saveBtn");

        protected override string PageTitle => "File upload cancelled";
    }
}
