using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_WithdrawSuccessfulPage : FAABasePage
    {
        protected override string PageTitle => $"You've successfully withdrawn from {vacancytitledataHelper.VacancyTitle}";

        protected override By PageHeader => By.CssSelector("#SuccessMessageText");

        public FAA_WithdrawSuccessfulPage(ScenarioContext context) : base(context) { }
    }
}
