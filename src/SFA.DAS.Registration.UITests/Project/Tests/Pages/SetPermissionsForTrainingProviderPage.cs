using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
   public class SetPermissionsForTrainingProviderPage : RegistrationBasePage
    {

        protected override By PageHeader => By.CssSelector(".govuk-heading-l");
        protected override string PageTitle => "Set permissions";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        protected By ApprenticeAllowRadioOption => By.Id("operation-0-yes");
        protected By RecruitAllowRadioOption => By.Id("operation-1-yes");
        protected By ApprenticeDoNotAllowRadioOption => By.Id("operation-0-no");
        protected By RecruitDoNotAllowRadioOption => By.Id("operation-1-no");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SetPermissionsForTrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public SetPermissionsForTrainingProviderPage ClickAllowToAddApprenticeRecords()
        {
            javaScriptHelper.ClickElement(ApprenticeAllowRadioOption);
            return this;
        }

        public ConfirmTrainingProviderPermissionsPage ClickAllowToRecruitApprentice()
        {
            javaScriptHelper.ClickElement(RecruitAllowRadioOption);
            Continue();
            return new ConfirmTrainingProviderPermissionsPage(_context);
        }

        public SetPermissionsForTrainingProviderPage ClickDoNotAllowToAddApprenticeRecords()
        {
            javaScriptHelper.ClickElement(ApprenticeDoNotAllowRadioOption);
            return this;
        }

        public ConfirmTrainingProviderPermissionsPage ClickDoNotAllowToRecruitApprentice()
        {
            javaScriptHelper.ClickElement(RecruitDoNotAllowRadioOption);
            Continue();
            return new ConfirmTrainingProviderPermissionsPage(_context);
        }
    }
}