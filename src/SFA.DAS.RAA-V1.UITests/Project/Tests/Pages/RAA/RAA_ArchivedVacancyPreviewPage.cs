using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ArchivedVacancyPreviewPage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".info-summary > p");

        protected override string PageTitle => "This vacancy has been archived";

        public RAA_ArchivedVacancyPreviewPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
