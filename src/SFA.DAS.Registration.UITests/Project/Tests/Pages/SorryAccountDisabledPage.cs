using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SorryAccountDisabledPage : RegistrationBasePage
    {
        protected override string PageTitle => "Sorry";

        #region Locators
        private By AddViaGGLink => By.LinkText("Try adding your PAYE scheme via Government Gateway");
        private By AccountDisabledInfo => By.CssSelector(".govuk-body");
        #endregion

        #region Constants
        public const string AccountDisabledInfoMessage = "Due to incorrect attempts, this has been disabled for 30 minutes.";
        #endregion

        public SorryAccountDisabledPage(ScenarioContext context) : base(context)
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(),
                () => VerifyPage(() => pageInteractionHelper.FindElements(AccountDisabledInfo), AccountDisabledInfoMessage)
            });
        }

        public UsingYourGovtGatewayDetailsPage ClickAddViaGGLink()
        {
            formCompletionHelper.Click(AddViaGGLink);
            return new UsingYourGovtGatewayDetailsPage(_context);
        }
    }
}