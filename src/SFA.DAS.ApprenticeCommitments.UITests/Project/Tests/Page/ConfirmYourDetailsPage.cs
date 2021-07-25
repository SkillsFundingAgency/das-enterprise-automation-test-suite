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

        public YouCantConfirmYourApprenticeship SelectNo()
        {
            formCompletionHelper.SelectRadioOptionByText("No");
            Continue();
            return new YouCantConfirmYourApprenticeship(_context);
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
