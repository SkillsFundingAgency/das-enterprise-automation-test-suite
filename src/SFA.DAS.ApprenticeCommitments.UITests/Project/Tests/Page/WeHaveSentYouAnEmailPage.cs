using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class WeHaveSentYouAnEmailPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "We have sent you an email";

        public WeHaveSentYouAnEmailPage(ScenarioContext context) : base(context, verifyserviceheader: false) { }
    }
}
