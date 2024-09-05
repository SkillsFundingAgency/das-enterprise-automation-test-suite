using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest
{
    public class RegisterInterestPage(ScenarioContext context) : CampaingnsVerifyLinks(context)
    {
        protected override string PageTitle => "Get emails about taking on your first apprentice";

        private static By FirstNameField => By.Id("FirstName");

        private static By LastNameField => By.Id("LastName");

        private static By EmailField => By.Id("Email");

        private static By SelectCompanySize => By.Id("SizeOfYourCompany");

        private static By LessthanTen => By.CssSelector("SizeOfYourCompany");
        private static By SelectIndustryDropdown => By.Id("Industry");
        private static By SelectRegionDropdown => By.Id("Location");

        private static By IncludeInUserResearch => By.Id("IncludeInUR");

        private static By Signup => By.CssSelector("#btn-register-interest-complete");

        public ThanksForSubscribingPage RegisterInterest()
        {
            formCompletionHelper.EnterText(FirstNameField, campaignsDataHelper.Firstname);
            formCompletionHelper.EnterText(LastNameField, campaignsDataHelper.Lastname);
            formCompletionHelper.EnterText(EmailField, campaignsDataHelper.Email);
            formCompletionHelper.SelectRadioOptionByText(SelectCompanySize, "Less than 10 employees");
            formCompletionHelper.SelectFromDropDownByText(SelectIndustryDropdown, campaignsDataHelper.Industry);
            formCompletionHelper.SelectFromDropDownByText(SelectRegionDropdown, campaignsDataHelper.Industry);
            formCompletionHelper.SelectCheckbox(IncludeInUserResearch);
            formCompletionHelper.ClickElement(Signup);
            return new ThanksForSubscribingPage(context);
        }
    }
}
