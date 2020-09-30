using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class SettingItUpPage : EmployerBasePage
    {
        protected override string PageTitle => "Setting it up";
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Page Object Elements
        private readonly By _hiringAnApprenticeIconLink = By.Id("flow-link-1");
        private readonly By _upskillingYourCurrentStaffIconLink = By.Id("flow-link-2");
        private readonly By _fundingAnApprenticeshipIconLink = By.Id("flow-link-3");
        private readonly By _trainingYourApprenticeIconLink = By.Id("flow-link-4");
        private readonly By _endPointAssessmentsIconLink = By.Id("flow-link-5");
        private readonly By _levyPayerYes = By.Id("levyPayerYes");
        private readonly By _levyPayerNo = By.Id("levyPayerNo");
        private readonly By _continueButton = By.XPath("//button[ contains(@class,  'button')  and contains(text(), 'Continue')]");
        #endregion

        #region Helpers and Context
        #endregion

        public SettingItUpPage(ScenarioContext context) : base(context) { }
    }
}