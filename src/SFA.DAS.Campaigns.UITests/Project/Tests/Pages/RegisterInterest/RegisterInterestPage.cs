using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest
{
    public class RegisterInterestPage : CampaingnsVerifyLinks
    {
        protected override string PageTitle => "Sign up to receive our employer skills newsletter";

        private static By FirstNameField => By.Id("FirstName");

        private static By LastNameField => By.Id("LastName");

        private static By EmailField => By.Id("Email");

        private static By IncludeInUserResearch => By.Id("IncludeInUR");

        private static By Signup => By.CssSelector("#btn-register-interest-complete");

        public RegisterInterestPage(ScenarioContext context) : base(context)  { }

        public ThanksForSubscribingPage RegisterInterest()
        {
            formCompletionHelper.EnterText(FirstNameField, campaignsDataHelper.Firstname);
            formCompletionHelper.EnterText(LastNameField, campaignsDataHelper.Lastname);
            formCompletionHelper.EnterText(EmailField, campaignsDataHelper.Email);
            formCompletionHelper.SelectCheckbox(IncludeInUserResearch);
            formCompletionHelper.ClickElement(Signup);
            return new ThanksForSubscribingPage(context);
        }
    }
}
