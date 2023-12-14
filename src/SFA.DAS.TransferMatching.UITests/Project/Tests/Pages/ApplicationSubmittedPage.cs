using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ApplicationSubmittedPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "Your application has been submitted";

        protected override By PageHeader => PanelTitle;

        public HomePage ContinueToMyAccount()
        {
            formCompletionHelper.ClickLinkByText("Continue to my account");
            return new HomePage(context);
        }
    }
}