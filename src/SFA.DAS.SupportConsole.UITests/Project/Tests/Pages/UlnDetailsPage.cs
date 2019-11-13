using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class UlnDetailsPage : BasePage
    {
        protected override string PageTitle => _config.SupportConsoleUlnName;
        private const string StatusSectionHeaderText = "Status";
        private const string ApprenticeSectionHeaderText = "Apprentice";
        private const string TrainingSectionHeaderText = "Training";
        private const string DatesSectionHeaderText = "Dates";
        private const string PaymentsSectionHeaderText = "Payment";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly SupportConsoleConfig _config;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        #region Locators
        private By StatusSectionHeader => By.XPath("//h2[contains(text(),'Status')]");
        private By ApprenticeSectionHeader => By.XPath("//h2[contains(text(),'Apprentice')]");
        private By TrainingSectionHeader => By.XPath("//h2[contains(text(),'Training')]");
        private By DatesSectionHeader => By.XPath("//h2[contains(text(),'Dates')]");
        private By PaymentsSectionHeader => By.XPath("//h2[contains(text(),'Payment')]");
        #endregion

        public UlnDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public void VerifyUlnDetailsPageHeaders()
        {
            _pageInteractionHelper.VerifyText(StatusSectionHeader, StatusSectionHeaderText);
            _pageInteractionHelper.VerifyText(ApprenticeSectionHeader, ApprenticeSectionHeaderText);
            _pageInteractionHelper.VerifyText(TrainingSectionHeader, TrainingSectionHeaderText);
            _pageInteractionHelper.VerifyText(DatesSectionHeader, DatesSectionHeaderText);
            _pageInteractionHelper.VerifyText(PaymentsSectionHeader, PaymentsSectionHeaderText);
        }
    }
}