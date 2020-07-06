using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest
{
    public class RegisterInterestPage : CampaingnsPage
    {
        protected override string PageTitle => "REGISTER INTEREST";

        protected override By PageHeader => By.CssSelector(".heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FirstNameField => By.Id("FirstName");

        private By LastNameField => By.Id("LastName");

        private By EmailField => By.Id("Email");

        private By IncludeInUserResearch = By.Id("IncludeInUR");

        private By RadioLabel => By.CssSelector(".radios__label");

        private By RegisterMyInterest => By.CssSelector("#btn-register-interest-complete");

        public RegisterInterestPage(ScenarioContext context) : base(context) => _context = context;

        public RegisterMyInterestSuccessPage RegisterInterestAsAnApprentice()
        {
            RegisterInterest("I want to become an apprentice");
            return new RegisterMyInterestSuccessPage(_context);
        }

        public ThanksForSubscribingPage RegisterInterestAsAnEmployer()
        {
            RegisterInterest("I want to employ an apprentice");
            return new ThanksForSubscribingPage(_context);
        }

        private void RegisterInterest(string role)
        {
            formCompletionHelper.EnterText(FirstNameField, campaignsDataHelper.Firstname);
            formCompletionHelper.EnterText(LastNameField, campaignsDataHelper.Lastname);
            formCompletionHelper.EnterText(EmailField, campaignsDataHelper.Email);
            formCompletionHelper.SelectRadioOptionByText(RadioLabel, role);
            formCompletionHelper.SelectCheckbox(IncludeInUserResearch);
            formCompletionHelper.ClickElement(RegisterMyInterest);
        }
    }
}
