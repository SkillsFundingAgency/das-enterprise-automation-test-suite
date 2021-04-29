using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class DoYouGiveTrainingProviderPermissionToAddApprenticeRecordsPage : RegistrationBasePage

    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-l");
        protected override string PageTitle => "Set permissions";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public DoYouGiveTrainingProviderPermissionToAddApprenticeRecordsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public DoYouGiveTrainingProviderPermissionToRecruitApprenticesPage ClickYesToAddApprenticeRecords() => SelectOption("Allow");

        public DoYouGiveTrainingProviderPermissionToRecruitApprenticesPage ClickNoToAddApprenticeRecords() => SelectOption("Do not allow");

        private DoYouGiveTrainingProviderPermissionToRecruitApprenticesPage SelectOption(string option)
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, option);
            Continue();
            return new DoYouGiveTrainingProviderPermissionToRecruitApprenticesPage(_context);
        }
    }
}