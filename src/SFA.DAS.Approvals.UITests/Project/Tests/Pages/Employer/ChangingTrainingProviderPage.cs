using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ChangingTrainingProviderPage : ApprovalsBasePage
    {
        protected override By PageHeader => By.TagName("h1");
        protected override string PageTitle => "Changing training provider";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.XPath("//a[contains(text(),'Continue')]");

        public ChangingTrainingProviderPage(ScenarioContext context) : base(context) => _context = context;

        public EnterUkprnPage ClickOnContinueButton()
        {
            Continue();
            return new EnterUkprnPage(_context);
        } 
    }
}
