using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedEmployerPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "You have confirmed your employer";
        private By NotificationBar => By.CssSelector(".app-notification-banner");

        public AlreadyConfirmedEmployerPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyText(NotificationBar, PageTitle);
            VerifyPage(ConfirmingEntityNamePageHeader, context.Get<ObjectContext>().GetEmployerName().Replace("  "," "));
        }
    }
}
