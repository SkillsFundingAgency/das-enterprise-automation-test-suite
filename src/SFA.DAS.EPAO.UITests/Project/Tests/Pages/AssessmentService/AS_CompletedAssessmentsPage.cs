using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using NUnit.Framework;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_CompletedAssessmentsPage : BasePage
    {
        protected override string PageTitle => "Completed assessments";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        #region Locators
        private By ApprenticeColumnLabel => By.XPath("(//th[@class='govuk-table__header'])[1]");
        private By ULNColumnLabel => By.XPath("(//th[@class='govuk-table__header'])[2]");
        private By EmployerColumnLabel => By.XPath("(//th[@class='govuk-table__header'])[3]");
        private By TrainingProviderColumnLabel => By.XPath("(//th[@class='govuk-table__header'])[4]");
        private By DateRequestedColumnLabel => By.XPath("(//th[@class='govuk-table__header'])[5]");
        #endregion

        public AS_CompletedAssessmentsPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public void VerifyTableHeaders()
        {
            Assert.AreEqual(_pageInteractionHelper.GetText(ApprenticeColumnLabel), "Apprentice");
            Assert.AreEqual(_pageInteractionHelper.GetText(ULNColumnLabel), "ULN");
            Assert.AreEqual(_pageInteractionHelper.GetText(EmployerColumnLabel), "Employer");
            Assert.AreEqual(_pageInteractionHelper.GetText(TrainingProviderColumnLabel), "Training provider");
            Assert.AreEqual(_pageInteractionHelper.GetText(DateRequestedColumnLabel), "Date requested");
        }
    }
}
