using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages
{
    public class ServiceStartPage : IdamsLoginBasePage
    {
        protected override string PageTitle => "ESFA admin services";

        private By StartNowCssSelector => By.CssSelector(".govuk-button--start");

        public ServiceStartPage(ScenarioContext context) : base(context) { }

        public IdamsPage StartNow()
        {
            ClickStartNowButton();
            return new IdamsPage(context);
        }

        public void ClickStartNowButton() => formCompletionHelper.ClickElement(StartNowCssSelector);

    }
}
