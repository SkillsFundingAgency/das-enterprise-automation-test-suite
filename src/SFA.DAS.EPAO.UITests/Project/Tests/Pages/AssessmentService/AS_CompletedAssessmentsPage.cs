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
        private By ApprenticeColumnLabel => By.XPath("//th[contains(text(),'Apprentice')]");
        private By ULNColumnLabel => By.XPath("//th[contains(text(),'ULN')]");
        private By EmployerColumnLabel => By.XPath("//th[contains(text(),'Employer')]");
        private By TrainingProviderColumnLabel => By.XPath("//th[contains(text(),'Training provider')]");
        private By DateRequestedColumnLabel => By.XPath("//th[contains(text(),'Date requested')]");
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
