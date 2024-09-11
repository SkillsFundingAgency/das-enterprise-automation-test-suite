using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private static By SizeOfYourCompanylabel => By.CssSelector("label[for=SizeOfYourCompany]");
        private static By SelectCompanySize => By.CssSelector(".govuk-radios__label");
        private static By SelectIndustryDropdown => By.CssSelector("#Industry");  
        private static By SelectRegionDropdown => By.CssSelector("#Location");
        private static By IncludeInURLabel => By.CssSelector("label[for=IncludeInUR]");
        private static By Signup => By.CssSelector("#btn-register-interest-complete");
        #endregion

        public ThanksForSubscribingPage RegisterInterest()
        {
            formCompletionHelper.EnterText(FirstNameField, campaignsDataHelper.Firstname);
            formCompletionHelper.EnterText(LastNameField, campaignsDataHelper.Lastname);
            formCompletionHelper.EnterText(EmailField, campaignsDataHelper.Email);

            var empSize = pageInteractionHelper.FindElements(SizeOfYourCompanylabel).Select(x => x.Text).ToList();
            formCompletionHelper.SelectRadioOptionByText(SelectCompanySize, GetRandomOption(empSize));

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
