using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class WeHaveSentYouAnEmailPage(ScenarioContext context) : ApprenticeCommitmentsBasePage(context, verifyserviceheader: false)
    {
        protected override string PageTitle => "We have sent you an email";
    }
}
