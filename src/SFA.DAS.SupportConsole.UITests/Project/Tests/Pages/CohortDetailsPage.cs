using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class CohortDetailsPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Cohort Details";

        #region Locators
        private By UlnViewLink => By.XPath("//a[contains(text(),'View')]");
        public By CohortRefNumber => By.XPath("//td[text()='Cohort reference:']/following-sibling::td");
        #endregion

        public CohortDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public void ClickViewUlnLink()
        {
            formCompletionHelper.Click(UlnViewLink);
            pageInteractionHelper.WaitforURLToChange("CommitmentApprenticeDetail");
        }

        public string GetCohortRefNumber()
        {
            return pageInteractionHelper.GetText(CohortRefNumber);
        }
    }
}