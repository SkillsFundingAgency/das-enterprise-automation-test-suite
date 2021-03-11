using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeHomePage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "My apprenticeship(s)";

        public ApprenticeHomePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
