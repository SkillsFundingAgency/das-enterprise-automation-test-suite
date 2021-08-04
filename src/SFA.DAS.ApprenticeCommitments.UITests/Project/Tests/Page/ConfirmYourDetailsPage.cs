using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.ApprenticeCommitments.APITests.Project;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class ConfirmYourDetailsPage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;
        private By ApprenticeshipInfo => By.XPath("//th[text()='Apprenticeship']/following-sibling::td");
        private By LevelInfo => By.XPath("//th[text()='Level']/following-sibling::td");
        private By EstimatedDurationInfo => By.XPath("//th[text()='Estimated duration']/following-sibling::td");
        private By PlannedStartDateInfo => By.XPath("//th[text()='Planned start date for training']/following-sibling::td");
        protected By GreenTickText => By.CssSelector(".app-notification-banner");
        protected By YourResponsibilitiesTab => By.XPath("//a[@id='tab_tab_you' and text()='Your responsibilities']");
        protected By YourEmployerTab => By.XPath("//a[@id='tab_tab_youremployer' and contains(text(),'Your employer')]");
        protected By YourTrainingProviderTab => By.XPath("//a[@id='tab_tab_yourprovider' and contains(text(),'Your training provider')]");
        protected By EmployerHelpSectionLink => By.XPath("//span[@class='govuk-details__summary-text' and contains(text(),\"Help if you do not recognise your employer's name\")]");
        protected By EmployerHelpSectionText => By.XPath($"//div[contains(text(),\"{objectContext.GetEmployerName()} is your employer's legal name registered with Companies House.  You may know them by their trading name instead.\")]");
        protected By ProviderHelpSectionLink => By.XPath("//span[@class='govuk-details__summary-text' and contains(text(),\"Help if you do not recognise your training provider's name\")]");
        protected By ProviderHelpSectionText => By.XPath($"//div[contains(text(),\"{objectContext.GetProviderName()} is your training provider's legal name registered with Companies House.\")]");

        public ConfirmYourDetailsPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            VerifyPage(HeaderText, $"{objectContext.GetFirstName()} {objectContext.GetLastName()}");
        }

        public ApprenticeHomePage SelectYes()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            Continue();
            return new ApprenticeHomePage(_context);
        }

        public YouCantConfirmYourEmployerPage SelectNoToConfirmEmployer()
        {
            formCompletionHelper.SelectRadioOptionByText("No");
            Continue();
            return new YouCantConfirmYourEmployerPage(_context);
        }

        public YouCantConfirmYourTrainingProviderPage SelectNoToConfirmTrainingProvider()
        {
            formCompletionHelper.SelectRadioOptionByText("No");
            Continue();
            return new YouCantConfirmYourTrainingProviderPage(_context);
        }

        public YouCantConfirmYourDetailsPage SelectNoConfirmYourDetails()
        {
            formCompletionHelper.SelectRadioOptionByText("No");
            Continue();
            return new YouCantConfirmYourDetailsPage(_context);
        }

        public string GetApprenticeshipInfo() => pageInteractionHelper.GetText(ApprenticeshipInfo);

        public string GetApprenticeshipLevelInfo() => pageInteractionHelper.GetText(LevelInfo);

        public string GetApprenticeshipEstimatedDurationInfo() => pageInteractionHelper.GetText(EstimatedDurationInfo);

        public string GetApprenticeshipPlannedStartDateInfo() => pageInteractionHelper.GetText(PlannedStartDateInfo);

        public void VerifyRolesYourResponsibilitiesTab() => VerifyPage(YourResponsibilitiesTab);

        public void VerifyRolesYourEmployerTab() => VerifyPage(YourEmployerTab);

        public void VerifyRolesYourTrainingProviderTab() => VerifyPage(YourTrainingProviderTab);
    }
}
