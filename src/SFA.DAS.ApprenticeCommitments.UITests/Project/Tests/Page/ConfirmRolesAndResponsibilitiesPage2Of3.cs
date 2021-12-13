using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmRolesAndResponsibilitiesPage2of3 : ConfirmYourRolesAbstractPage
    {
        protected override string PageTitle => "Your employer’s responsibilities";

        public ConfirmRolesAndResponsibilitiesPage2of3(ScenarioContext context) : base(context) => VerifyPage();

        public ConfirmRolesAndResponsibilitiesPage3of3 ConfirmEmployerRolesAndContinue()
        {
            SelectCheckBoxAndContinue();
            return new ConfirmRolesAndResponsibilitiesPage3of3(_context);
        }
    }
}
