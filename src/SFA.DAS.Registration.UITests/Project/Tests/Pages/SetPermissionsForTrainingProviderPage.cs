using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SetPermissionsForTrainingProviderPage : RegistrationBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-l, .govuk-heading-xl");
        protected override string PageTitle => "Set permissions";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        protected static By ApprenticeAllowRadioOption => By.Id("operation-0-yes");
        protected static By RecruitAllowRadioOption => By.Id("operation-1-yes");
        protected static By RecruitAllowConditionalRadioOption => By.Id("operation-1-conditional");
        protected static By ApprenticeDoNotAllowRadioOption => By.Id("operation-0-no");
        protected static By RecruitDoNotAllowRadioOption => By.Id("operation-1-no");

        #region Helpers and Context 

        #endregion

        public SetPermissionsForTrainingProviderPage(ScenarioContext context) : base(context) => VerifyPage();

        public SetPermissionsForTrainingProviderPage ClickAddApprentice(AddApprenticePermissions permission)
        {
            SetPermissionsForTrainingProviderPage Continue(By by)
            {
                javaScriptHelper.ClickElement(by);
                return this;
            }

            return permission switch
            {
                AddApprenticePermissions.AllowConditional => Continue(ApprenticeAllowRadioOption),
                _ => Continue(ApprenticeDoNotAllowRadioOption),
            };
        }

        public ConfirmTrainingProviderPermissionsPage ClickRecruitApprentice(RecruitApprenticePermissions permission)
        {
            ConfirmTrainingProviderPermissionsPage ContinueToConfirm(By by)
            {
                javaScriptHelper.ClickElement(by);
                Continue();
                return new ConfirmTrainingProviderPermissionsPage(context);
            }

            return permission switch
            {
                RecruitApprenticePermissions.Allow => ContinueToConfirm(RecruitAllowRadioOption),
                RecruitApprenticePermissions.AllowConditional => ContinueToConfirm(RecruitAllowConditionalRadioOption),
                _ => ContinueToConfirm(RecruitDoNotAllowRadioOption),
            };
        }
    }
}