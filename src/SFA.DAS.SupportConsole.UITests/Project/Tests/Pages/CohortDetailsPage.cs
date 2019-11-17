using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using NUnit.Framework;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class CohortDetailsPage : BasePage
    {
        protected override string PageTitle => "Cohort Details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly SupportConsoleConfig _config;
        #endregion

        #region Locators
        private By UlnViewLink => By.XPath("//a[contains(text(),'View')]");
        private By CohortRefNumber => By.XPath("//td[text()='Cohort reference:']/following-sibling::td");
        #endregion

        public CohortDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
            VerifyPage();
        }

        public void IsPageDisplayed()
        {
            VerifyPage();
        }

        public void ClickViewUlnLink()
        {
            Assert.AreEqual(_pageInteractionHelper.GetText(CohortRefNumber), _config.SupportConsoleCohortRef, "Cohort reference mismatch in CohortDetailsPage");
            _formCompletionHelper.Click(UlnViewLink);
        }
    }
}