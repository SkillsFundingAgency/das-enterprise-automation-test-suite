using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedEmployerPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "You have confirmed this is your employer";
        protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        public AlreadyConfirmedEmployerPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyText(NotificationBar, PageTitle);
            VerifyPage(PageHeader, objectContext.GetEmployerName().Replace("  "," "));
        }
    }
}
