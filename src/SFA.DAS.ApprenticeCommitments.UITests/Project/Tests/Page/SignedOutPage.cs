using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class SignedOutPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "You have successfully signed out";

        public SignedOutPage(ScenarioContext context) : base(context) { }

    }
}
