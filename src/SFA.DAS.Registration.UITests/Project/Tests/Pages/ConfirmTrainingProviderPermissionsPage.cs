using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ConfirmTrainingProviderPermissionsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm permissions";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        protected By SelectYesConfirmChange => By.Id("confirmation-yes");
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmTrainingProviderPermissionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        /*  public PermissionsUpdatedPage ConfirmTrainingProviderPermissions()
          {
              Continue();
              return new PermissionsUpdatedPage(_context);
          }
        */
        public PermissionsUpdatedPage ConfirmTrainingProviderPermissions()
        {
            Continue();
            return new PermissionsUpdatedPage(_context);
        }

        public PermissionsUpdatedPage ConfirmYesTrainingProviderPermissions()
        {
            javaScriptHelper.ClickElement(SelectYesConfirmChange);
            Continue();
            return new PermissionsUpdatedPage(_context);
        }

        public HomePage ConfirmProviderLeadRegistrationPermissions()
        {
            Continue();
            return new HomePage(_context);
        }
    }
}

