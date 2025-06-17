using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest
{
    public class SignUpPage(ScenarioContext context) : CampaingnsVerifyLinks(context)
    {
        protected override string PageTitle => "Get emails about taking on your first apprentice";

        #region PageObjects
        private static By FirstNameField => By.CssSelector("#FirstName");
        private static By LastNameField => By.CssSelector("#LastName");
        private static By EmailField => By.CssSelector("#Email");
        private static By RadioButtonlessthan10employees => By.CssSelector("#SizeOfYourCompany");
        private static By RadioButton10and49employees => By.CssSelector("#between10and49employees");
        private static By RadioButton50and249employees => By.CssSelector("#between50and249employees");
        private static By RadioButton250employees => By.CssSelector("#over250employees");
        private static By SelectIndustryDropdown => By.CssSelector("#Industry");  
        private static By SelectRegionDropdown => By.CssSelector("#Location");
        private static By IncludeInURLabel => By.CssSelector("label[for=IncludeInUR]");
        private static By Signup => By.CssSelector("#btn-register-interest-complete");
        #endregion

        public void YourDetails()
        {
            formCompletionHelper.EnterText(FirstNameField, campaignsDataHelper.Firstname);
            formCompletionHelper.EnterText(LastNameField, campaignsDataHelper.Lastname);
            formCompletionHelper.EnterText(EmailField, campaignsDataHelper.Email);
        }

        public void SelectCompanySizeOption1() => formCompletionHelper.SelectRadioOptionByLocator(RadioButtonlessthan10employees);
        public void SelectCompanySizeOption2() => formCompletionHelper.SelectRadioOptionByLocator(RadioButton10and49employees);
        public void SelectCompanySizeOption3() => formCompletionHelper.SelectRadioOptionByLocator(RadioButton50and249employees);
        public void SelectCompanySizeOption4() => formCompletionHelper.SelectRadioOptionByLocator(RadioButton250employees);

        public ThanksForSubscribingPage RegisterInterest()
        {
            var industryAllOptions = formCompletionHelper.GetAllDropDownOptions(SelectIndustryDropdown);
            formCompletionHelper.SelectFromDropDownByText(SelectIndustryDropdown, GetRandomOption(industryAllOptions));

            var RegionAllOptions = formCompletionHelper.GetAllDropDownOptions(SelectRegionDropdown);
            formCompletionHelper.SelectFromDropDownByText(SelectRegionDropdown, GetRandomOption(RegionAllOptions));

            formCompletionHelper.Click(IncludeInURLabel);
            formCompletionHelper.Click(Signup);
            return new ThanksForSubscribingPage(context);
        }

        private static string GetRandomOption(List<string> options) => RandomDataGenerator.GetRandomElementFromListOfElements(options);
    }
}
