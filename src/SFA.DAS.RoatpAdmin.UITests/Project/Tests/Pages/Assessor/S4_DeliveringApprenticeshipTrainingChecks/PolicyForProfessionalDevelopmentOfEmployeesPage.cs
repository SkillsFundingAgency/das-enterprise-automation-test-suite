using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class PolicyForProfessionalDevelopmentOfEmployeesPage : AssessorBasePage
    {
        protected override string PageTitle => "Policy for professional development of employees";
        
        public PolicyForProfessionalDevelopmentOfEmployeesPage(ScenarioContext context) : base(context) { }

        public AnExampleOfHowThePolicyToImprovePage SelectPassAndContinueInPolicyForProfessionalDevelopmentOfEmployeesPage()
        {
            SelectPassAndContinueToSubSection();
            return new AnExampleOfHowThePolicyToImprovePage(context);
        }
    }
}