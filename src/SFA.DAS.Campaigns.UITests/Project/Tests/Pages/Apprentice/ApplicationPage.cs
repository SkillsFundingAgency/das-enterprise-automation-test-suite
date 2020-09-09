using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApplicationPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Error";


        public ApplicationPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}
