using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class CheckYourAnswersPage(ScenarioContext context) : BasePage(context)
    {
        protected override string PageTitle => "Check your answers";


        #region Locators
        private static By ClickChangeHowManyApprentices => By.XPath("(//dd[@class='govuk-summary-list__actions']/a[@class='govuk-link'])[1]");
        private static By ClickChangeOneApprenticeshipLocation => By.XPath("(//dd[@class='govuk-summary-list__actions']/a[@class='govuk-link'])[2]");
        private static By ClickChangeApprenticeshipLocations => By.XPath("(//dd[@class='govuk-summary-list__actions']/a[@class='govuk-link'])[3]");
        private static By ClickChangeTrainingOptions => By.XPath("(//dd[@class='govuk-summary-list__actions']/a[@class='govuk-link'])[4]");
        #endregion

        public CheckYourAnswersPage ClickChangelinks()
        {
            formCompletionHelper.Click(ClickChangeHowManyApprentices);
            formCompletionHelper.Click(ClickChangeOneApprenticeshipLocation);
            formCompletionHelper.Click(ClickChangeApprenticeshipLocations);
            formCompletionHelper.Click(ClickChangeApprenticeshipLocations);
            Continue();
            return new CheckYourAnswersPage(context);
        }
    }
}
