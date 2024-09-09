using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest
{
    public class SignUpPage(ScenarioContext context) : CampaingnsVerifyLinks(context)
    {
        protected override string PageTitle => "Get emails about taking on your first apprentice";

        #region PageObjects
        private static By FirstNameField => By.Id("FirstName");
        private static By LastNameField => By.Id("LastName");
        private static By EmailField => By.Id("Email");   
        private static By SelectCompanySize => By.CssSelector(".govuk-radios__label");
        private static By SelectIndustryDropdown => By.XPath("//*[@id=\"Industry\"]");  
        private static By SelectRegionDropdown => By.CssSelector("#Location");
        private static By IncludeInUserResearch => By.CssSelector("#IncludeInUR");
        private static By Signup => By.CssSelector("#btn-register-interest-complete");
        #endregion

        public SignUpPage EnterPersonalDetails()
        {
            formCompletionHelper.EnterText(FirstNameField, campaignsDataHelper.Firstname);
            formCompletionHelper.EnterText(LastNameField, campaignsDataHelper.Lastname);
            formCompletionHelper.EnterText(EmailField, campaignsDataHelper.Email);
            formCompletionHelper.SelectRadioOptionByText(SelectCompanySize, campaignsDataHelper.EmployeesSize);
            return new SignUpPage(context);
        }
        public ThanksForSubscribingPage RegisterInterest()
        { 
            var webDriver = context.GetWebDriver();
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(SelectIndustryDropdown));
            formCompletionHelper.SelectFromDropDownByText(SelectIndustryDropdown, campaignsDataHelper.Industry);
            formCompletionHelper.SelectFromDropDownByText(SelectRegionDropdown, campaignsDataHelper.Region);
            Thread.Sleep(2000);
            formCompletionHelper.SelectCheckbox(IncludeInUserResearch);
            formCompletionHelper.ClickElement(Signup);
            return new ThanksForSubscribingPage(context);
        }
    }
}
