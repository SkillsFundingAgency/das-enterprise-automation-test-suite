using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_WithdrawSuccessfulPage(ScenarioContext context) : FAABasePage(context)
    {
        protected override string PageTitle => $"You've successfully withdrawn from {vacancyTitleDataHelper.VacancyTitle}";

        protected override string AccessibilityPageTitle => "You've successfully withdrawn from vacancy title";

        protected override By PageHeader => By.CssSelector("#SuccessMessageText");
    }
}
