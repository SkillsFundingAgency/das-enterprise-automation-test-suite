using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ChangeOfTrainingProviderRequestedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Change of training provider requested";
        private readonly ScenarioContext _context;
        public ChangeOfTrainingProviderRequestedPage(ScenarioContext context) : base(context) => _context = context;
    
    }
}
