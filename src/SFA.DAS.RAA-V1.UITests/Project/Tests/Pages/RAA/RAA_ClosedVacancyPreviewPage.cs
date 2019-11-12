using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ClosedVacancyPreviewPage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".info-summary > p");

        protected override string PageTitle => "This vacancy is now closed";

        public RAA_ClosedVacancyPreviewPage(ScenarioContext context) : base(context) 
        { 
            VerifyPage(); 
        }
    }

    public class RAA_ChangeVacancyDatePreviewPage : BasePage
    {
        protected override By PageHeader => By.CssSelector("#SuccessMessageText");

        protected override string PageTitle => "Your changes have been saved successfully";

        public RAA_ChangeVacancyDatePreviewPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
