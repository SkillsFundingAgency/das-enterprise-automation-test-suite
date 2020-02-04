using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_CompletedAssessmentsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Completed assessments";

        #region Locators
        private By ApprenticeColumnLabel => By.XPath("//th[contains(text(),'Apprentice')]");
        private By ULNColumnLabel => By.XPath("//th[contains(text(),'ULN')]");
        private By EmployerColumnLabel => By.XPath("//th[contains(text(),'Employer')]");
        private By TrainingProviderColumnLabel => By.XPath("//th[contains(text(),'Training provider')]");
        private By DateRequestedColumnLabel => By.XPath("//th[contains(text(),'Date requested')]");
        #endregion

        public AS_CompletedAssessmentsPage(ScenarioContext context) : base(context) => VerifyPage();

        public void VerifyTableHeaders()
        {
            Assert.AreEqual(pageInteractionHelper.GetText(ApprenticeColumnLabel), "Apprentice");
            Assert.AreEqual(pageInteractionHelper.GetText(ULNColumnLabel), "ULN");
            Assert.AreEqual(pageInteractionHelper.GetText(EmployerColumnLabel), "Employer");
            Assert.AreEqual(pageInteractionHelper.GetText(TrainingProviderColumnLabel), "Training provider");
            Assert.AreEqual(pageInteractionHelper.GetText(DateRequestedColumnLabel), "Date requested");
        }
    }
}
