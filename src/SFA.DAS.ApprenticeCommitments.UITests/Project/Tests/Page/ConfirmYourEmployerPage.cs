using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourEmployerPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Confirm your employer";

        public ConfirmYourEmployerPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
