using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderFileDiscadSuccessPage : ApprovalsBasePage
    {
        protected override By ContinueButton => By.Id("saveBtn");

        protected override string PageTitle => "File upload cancelled";

        public ProviderFileDiscadSuccessPage(ScenarioContext context) : base(context) { }
    }
}
