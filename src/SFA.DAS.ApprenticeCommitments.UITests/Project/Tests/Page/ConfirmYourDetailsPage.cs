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
        private By DurationInfo => By.XPath("//th[text()='Duration']/following-sibling::td");
        private By PlannedStartDateInfo => By.XPath("//th[text()='Planned start date']/following-sibling::td");
        private By PlannedEndDateInfo => By.XPath("//th[text()='Planned end date']/following-sibling::td");
        protected By NotificationBar => By.CssSelector(".app-notification-banner");
        protected By RolesYouTabHeaderText => By.XPath("//div[@class='govuk-tabs__panel']/h3[text()='Your responsibilities']/following-sibling::p[text()='These roles and responsibilities set out what is expected of you.']");
        protected By RolesYourEmployerTab => By.Id("tab_tab_youremployer");
        protected By RolesYourEmployerTabHeaderText => By.XPath("//div[@id='tab_youremployer']/h3[contains(text(),'Your employer')]");
        protected By RolesYourTrainingProviderTab => By.Id("tab_tab_yourprovider");
        protected By RolesYourTrainingProviderTabHeaderText => By.XPath("//div[@id='tab_yourprovider']/h3[text()='Your training provider’s responsibilities']");

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

        public string GetApprenticeshipDurationInfo() => pageInteractionHelper.GetText(DurationInfo);

        public string GetApprenticeshipPlannedStartDateInfo() => pageInteractionHelper.GetText(PlannedStartDateInfo);

        public string GetApprenticeshipPlannedEndDateInfo() => pageInteractionHelper.GetText(PlannedEndDateInfo);

        public void VerifyRolesYouTab() => VerifyPage(RolesYouTabHeaderText);

        public void VerifyRolesYourEmployerTab()
        {
            formCompletionHelper.Click(RolesYourEmployerTab);
            VerifyPage(RolesYourEmployerTabHeaderText);
        }

        public void VerifyRolesYourTrainingProviderTab()
        {
            formCompletionHelper.Click(RolesYourTrainingProviderTab);
            VerifyPage(RolesYourTrainingProviderTabHeaderText);
        }
    }
}
