using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedTrainingProviderPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "You have confirmed this is your training provider";
        protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        public AlreadyConfirmedTrainingProviderPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyText(NotificationBar, PageTitle);
            VerifyPage(PageHeader, objectContext.GetProviderName());
        }
    }
}
