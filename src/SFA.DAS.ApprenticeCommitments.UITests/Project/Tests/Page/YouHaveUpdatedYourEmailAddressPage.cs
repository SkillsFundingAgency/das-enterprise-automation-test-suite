using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class YouHaveUpdatedYourEmailAddressPage(ScenarioContext context) : EmailAndPasswordSuccessfulBasePage(context)
    {
        protected override string PageTitle => "You have updated your email address";
    }
}
