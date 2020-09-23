using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmpBenefitsPage : EmployerBasePage
    {
        protected override string PageTitle => "Page not found";
        public EmpBenefitsPage(ScenarioContext context) : base(context) 
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}
