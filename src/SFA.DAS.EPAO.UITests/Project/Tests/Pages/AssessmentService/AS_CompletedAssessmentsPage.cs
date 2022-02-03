using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_CompletedAssessmentsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Completed assessments";

        #region Locators
        private By ApprenticeColumnLabel => By.LinkText("Apprentice");
        private By ULNColumnLabel => By.XPath("//th[contains(text(),'ULN')]");
        private By EmployerColumnLabel => By.LinkText("Employer");
        private By TrainingProviderColumnLabel => By.LinkText("Training provider");
        private By DateRequestedColumnLabel => By.LinkText("Date requested");
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