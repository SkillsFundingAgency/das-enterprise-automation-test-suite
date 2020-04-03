using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ReferVacancyPage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-error-summary__title");

        protected override string PageTitle => "Edits needed";

        public ReferVacancyPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
