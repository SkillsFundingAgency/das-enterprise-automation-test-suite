using OpenQA.Selenium;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_IndexPage : RAAV1BasePage
    {
        protected override string PageTitle => "Recruitment";

        private readonly By AgencyButton = By.CssSelector(".button");

        public Manage_IndexPage(ScenarioContext context) : base(context) { }

        public IdamsPage ClickAgencyButton()
        {
            formCompletionHelper.Click(AgencyButton);
            return new IdamsPage(context);
        }
    }
}
