using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class YouHaveUpdatedYourEmailAddressPage : EmailAndPasswordSuccessfulBasePage
    {
        protected override string PageTitle => "You have updated your email address";

        public YouHaveUpdatedYourEmailAddressPage(ScenarioContext context) : base(context) { }
    }
}
