using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class ContactDetailsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "View contact";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        public ContactDetailsPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
