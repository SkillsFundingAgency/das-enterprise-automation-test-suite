using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmRolesAndResponsibilitiesPage3of3 : ConfirmYourRolesAbstractPage
    {
        protected override string PageTitle => "Your training provider’s responsibilities";

        public ConfirmRolesAndResponsibilitiesPage3of3(ScenarioContext context) : base(context) => VerifyPage();

        public ApprenticeOverviewPage ConfirmTrainingProviderRolesAndContinue()
        {
            SelectCheckBoxAndContinue();
            return new ApprenticeOverviewPage(_context);
        }
    }
}
