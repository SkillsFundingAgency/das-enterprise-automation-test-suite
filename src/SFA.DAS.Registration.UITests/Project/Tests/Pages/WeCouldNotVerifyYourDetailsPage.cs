using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class WeCouldNotVerifyYourDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "We could not verify your details";

        #region Locators
        private static By AddViaGGLink => By.LinkText("Try adding your PAYE scheme via Government Gateway");
        private static By AccountDisabledInfo => By.CssSelector(".govuk-inset-text");
        #endregion

        #region Constants
        public const string AccountDisabledInfoMessage = "You have attempted to sign in to HMRC with the wrong details too many times.";
        #endregion

        public WeCouldNotVerifyYourDetailsPage(ScenarioContext context) : base(context)
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
            return new UsingYourGovtGatewayDetailsPage(context);
        }
    }
}