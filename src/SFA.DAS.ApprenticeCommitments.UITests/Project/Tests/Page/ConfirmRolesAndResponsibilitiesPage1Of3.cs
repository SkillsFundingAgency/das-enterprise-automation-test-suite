using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmRolesAndResponsibilitiesPage1of3 : ConfirmYourRolesAbstractPage
    {
        protected override string PageTitle => "Your responsibilities as an apprentice";

        public ConfirmRolesAndResponsibilitiesPage1of3(ScenarioContext context) : base(context) => VerifyPage();

        public ConfirmRolesAndResponsibilitiesPage2of3 ConfirmYourRolesAndContinue()
        {
            SelectCheckBoxAndContinue();
            return new ConfirmRolesAndResponsibilitiesPage2of3(_context);
        }
    }
}
