using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class CohortSummaryPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Cohort Summary";

        #region Locators
        public By CohortRefNumber => By.XPath("//td[text()='Cohort reference']/following-sibling::td");
        private By ViewThisCohortButton => By.Id("viewCohort");
        #endregion

        public CohortSummaryPage(ScenarioContext context) : base(context) => VerifyPage();

        public CohortDetailsPage ClickViewThisCohortButton()
        {
            formCompletionHelper.Click(ViewThisCohortButton);
            return new CohortDetailsPage(context);
        }

        public string GetCohortRefNumber()
        {
            return pageInteractionHelper.GetText(CohortRefNumber);
        }
    }
}