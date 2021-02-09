using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ChangeOfTrainingProviderRequestedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Change of training provider requested";
        private readonly ScenarioContext _context;

        private string EmployerLedExpectedBodyText => $"We'll ask {changeOfPartyConfig.NewProviderName} to check the details of this change. If they make any changes, it will come back to you.";
        
        public ChangeOfTrainingProviderRequestedPage(ScenarioContext context) : base(context) => _context = context;                 
        
        public void VerifyConfirmationMessage()
        {
            var bodyTextElements = pageInteractionHelper.FindElements(By.CssSelector(".govuk-body"));

            Assert.AreEqual(EmployerLedExpectedBodyText, bodyTextElements.First().Text);
        }
    }
}
