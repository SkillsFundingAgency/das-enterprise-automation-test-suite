using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedApprenticeshipDetailsPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "You have confirmed your apprenticeship details";
        private By NotificationBar => By.CssSelector(".app-notification-banner");

        public AlreadyConfirmedApprenticeshipDetailsPage(ScenarioContext context) : base(context, false)
        {
            pageInteractionHelper.VerifyText(NotificationBar, PageTitle);
        }
    }
}
