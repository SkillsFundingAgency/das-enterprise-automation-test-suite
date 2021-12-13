using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public enum AddApprenticePermissions
    {
        Allow,
        DoNotAllow
    }

    public enum RecruitApprenticePermissions
    {
        Allow,
        AllowConditional,
        DoNotAllow
    }


   public class SetPermissionsForTrainingProviderPage : RegistrationBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-l");
        protected override string PageTitle => "Set permissions";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        protected By ApprenticeAllowRadioOption => By.Id("operation-0-yes");
        protected By RecruitAllowRadioOption => By.Id("operation-1-yes");
        protected By RecruitAllowConditionalRadioOption => By.Id("operation-1-conditional");
        protected By ApprenticeDoNotAllowRadioOption => By.Id("operation-0-no");
        protected By RecruitDoNotAllowRadioOption => By.Id("operation-1-no");

        #region Helpers and Context
        
        #endregion

        public SetPermissionsForTrainingProviderPage(ScenarioContext context) : base(context) => VerifyPage();

        public SetPermissionsForTrainingProviderPage ClickAddApprentice(AddApprenticePermissions permission)
        {
            return permission switch
            {
                AddApprenticePermissions.Allow => Continue(ApprenticeAllowRadioOption),
                _ => Continue(ApprenticeDoNotAllowRadioOption),
            };
        }

        public ConfirmTrainingProviderPermissionsPage ClickRecruitApprentice(RecruitApprenticePermissions permission)
        {
            return permission switch
            {
                RecruitApprenticePermissions.Allow => ContinueToConfirm(RecruitAllowRadioOption),
                RecruitApprenticePermissions.AllowConditional => ContinueToConfirm(RecruitAllowConditionalRadioOption),
                _ => ContinueToConfirm(RecruitDoNotAllowRadioOption),
            };
        }

        private SetPermissionsForTrainingProviderPage Continue(By by)
        {
            javaScriptHelper.ClickElement(by);
            return this;
        }

        private ConfirmTrainingProviderPermissionsPage ContinueToConfirm(By by)
        {
            javaScriptHelper.ClickElement(by);
            Continue();
            return new ConfirmTrainingProviderPermissionsPage(_context);
        }
    }
}