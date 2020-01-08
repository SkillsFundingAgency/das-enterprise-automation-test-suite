using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class CohortDetailsPage : BasePage
    {
        protected override string PageTitle => "Cohort Details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        #region Locators
        private By UlnViewLink => By.XPath("//a[contains(text(),'View')]");
        public By CohortRefNumber => By.XPath("//td[text()='Cohort reference:']/following-sibling::td");
        #endregion

        public CohortDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public void ClickViewUlnLink()
        {
            _formCompletionHelper.Click(UlnViewLink);
            _pageInteractionHelper.WaitforURLToChange("CommitmentApprenticeDetail");
        }

        public string GetCohortRefNumber()
        {
            return _pageInteractionHelper.GetText(CohortRefNumber);
        }
    }
}