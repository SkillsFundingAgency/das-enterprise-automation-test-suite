/*
 using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class DoYouGiveTrainingProviderPermissionToRecruitApprenticesPage : RegistrationBasePage
    {
        protected override By PageHeader => By.CssSelector("h1.govuk-fieldset__heading");
        protected override string PageTitle => "Do you give";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public DoYouGiveTrainingProviderPermissionToRecruitApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmTrainingProviderPermissionsPage ClickYesToAddRecruitApprentice() => SelectOption("Yes");
        
        public ConfirmTrainingProviderPermissionsPage ClickNoToAddRecruitApprentice() => SelectOption("No");
        
        private ConfirmTrainingProviderPermissionsPage SelectOption(string option)
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, option);
            Continue();
            return new ConfirmTrainingProviderPermissionsPage(_context);
        }
    }
}
*/