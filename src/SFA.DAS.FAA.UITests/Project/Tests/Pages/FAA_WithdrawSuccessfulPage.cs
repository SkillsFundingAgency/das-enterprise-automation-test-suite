using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_WithdrawSuccessfulPage : FAABasePage
    {
        protected override string PageTitle => $"You've successfully withdrawn from {_vacancytitledataHelper.VacancyTitle}";

        protected override By PageHeader => By.CssSelector("#SuccessMessageText");

        public FAA_WithdrawSuccessfulPage(ScenarioContext context) : base(context) { }
    }
}
