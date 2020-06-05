using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class UlnDetailsPage : SupportConsoleBasePage
    {
        protected override string PageTitle => config.UlnName;
        private string StatusSectionHeaderText => "Status";
        private string ApprenticeSectionHeaderText => "Apprentice";
        private string TrainingSectionHeaderText => "Training";
        private string DatesSectionHeaderText => "Dates";
        private string PaymentsSectionHeaderText => "Payment";

        #region Locators
        private By StatusSectionHeader => By.XPath("//h2[contains(text(),'Status')]");
        private By ApprenticeSectionHeader => By.XPath("//h2[contains(text(),'Apprentice')]");
        private By TrainingSectionHeader => By.XPath("//h2[contains(text(),'Training')]");
        private By DatesSectionHeader => By.XPath("//h2[contains(text(),'Dates')]");
        private By PaymentsSectionHeader => By.XPath("//h2[contains(text(),'Payment')]");
        #endregion

        public UlnDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public void VerifyUlnDetailsPageHeaders()
        {
            pageInteractionHelper.VerifyText(StatusSectionHeader, StatusSectionHeaderText);
            pageInteractionHelper.VerifyText(ApprenticeSectionHeader, ApprenticeSectionHeaderText);
            pageInteractionHelper.VerifyText(TrainingSectionHeader, TrainingSectionHeaderText);
            pageInteractionHelper.VerifyText(DatesSectionHeader, DatesSectionHeaderText);
            pageInteractionHelper.VerifyText(PaymentsSectionHeader, PaymentsSectionHeaderText);
        }
    }
}