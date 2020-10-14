using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmpBenefitsPage : EmployerBasePage
    {
        protected override string PageTitle => "What are the benefits of hiring an apprentice?";

        public EmpBenefitsPage(ScenarioContext context) : base(context) { }
    }
}