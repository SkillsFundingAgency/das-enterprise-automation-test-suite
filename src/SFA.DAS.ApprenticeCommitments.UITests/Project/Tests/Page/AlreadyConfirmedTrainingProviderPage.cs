using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedTrainingProviderPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "You have confirmed your training provider";
        private By NotificationBar => By.CssSelector(".app-notification-banner");

        public AlreadyConfirmedTrainingProviderPage(ScenarioContext context) : base(context, false)
        {
            pageInteractionHelper.VerifyText(NotificationBar, PageTitle);
            VerifyPage(PageHeader, context.Get<ObjectContext>().GetProviderName());
        }
    }
}
