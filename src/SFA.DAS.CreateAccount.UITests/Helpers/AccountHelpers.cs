using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SFA.DAS.CreateAccount.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Helpers
{
    internal class AccountHelpers
    {
        private readonly ScenarioContext _context;
        private readonly CreateAccountConfig _config;

        public AccountHelpers(ScenarioContext context)
        {
            _context = context;
            _config = context.Get<CreateAccountConfig>();
        }

        public SqlDatabaseConncetionHelper sqlDatabaseConnectionHelper = new SqlDatabaseConncetionHelper();

        internal string GenerateRandEmail()
        {
            //ToDo : refactor based on environements
            //if (EnvConfigurator.GetEnvConfigInstance().ExecutionEnvironment.Equals("Local"))
            //    return $"MA_Test_LocalRun{System.DateTime.Now.ToString("ddMMMyyyy_HHmmss")}@mailinator.com";
            //else
                return $"MA_Test_{System.DateTime.Now.ToString("ddMMMyyyy_HHmmss")}@mailinator.com";
        }

        public string CreateAnUserAccount(IWebDriver WebBrowserDriver, bool signOut = false, string predefinedEmail = null, bool unactivated = false)
        {
            var accountEmail = GenerateRandEmail();
            var page = _context
                .SiteHomepage()
                .ClickCreateAccountButton()
                .SubmitValidForm(UserAccountConstants.LastName, UserAccountConstants.FirstName, accountEmail, _config.MACurrentUserPassword, _config.MACurrentUserPassword);

            if (unactivated)
                return accountEmail;

            page.ValidAccesCode(UserAccountConstants.ValidAccessCode);
            if (signOut)
            {
                _context.AccountSettingsPage().ClickSignOut();
                _context.SignOutPage().ClickContinue();
            }

            System.Diagnostics.Debug.WriteLine($"Account with email: '{accountEmail}' is created.");

            return accountEmail;
        }

        #region stage3 
        //uncomment when we are in Stage 3 
        //internal string AddCompanyTypeOrgToUserAccount(IWebDriver WebBrowserDriver, bool existingUser = false)
        //{
        //    if (!existingUser)
        //    {
        //        _context.GetApprenticeshipFundingPage().SelectYesAddMyPAYESchemeDetailsNowRadioButton();
        //        _context.GetApprenticeshipFundingPage().ClickContinueButton();
        //    }
        //    _context.UsingYourGovtGatewayDetailsPage().Continue();

        //    var scheme = GovernmentIdPicker.PickASuitableId(WebBrowserDriver);

        //    _context
        //       .SearchForYourOrganisationPage().SetOrganisationName(CompanyTypeOrgConstants.CompaniesHouseNumber)
        //       .Continue()
        //       .SelectFirstResultWithConfirm();

        //    _context.SummaryPayePage().Continue();

        //    return scheme;
        //}


        //public void UpdateLegalEntityName(string email)
        //{
        //    List<object[]> responseData = sqlDatabaseConnectionHelper.ReadDataFromDataBase(
        //        "SELECT Id from [employer_account].[User] where Email = '" + email + "'", _accDatabase);
        //    var id = Convert.ToInt32(responseData[0][0]);
        //    responseData = sqlDatabaseConnectionHelper.ReadDataFromDataBase(
        //        "SELECT AccountId FROM [employer_account].[Membership] where UserId = " + id, _accDatabase);
        //    var accountId = Convert.ToInt32(responseData[0][0]);
        //    sqlDatabaseConnectionHelper.ExecuteSqlCommand(
        //        "UPDATE [employer_account].[AccountLegalEntity] set Name = 'Changed Org Name' where AccountId = " +
        //        accountId, _accDatabase);
        //}
        #endregion
    }
}