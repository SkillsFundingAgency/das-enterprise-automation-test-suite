using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class HireAnApprenticePage : EmployerBasePage
    {
        protected override string PageTitle => "Hiring an apprentice";

        public HireAnApprenticePage(ScenarioContext context) : base(context) { }
    }
}

