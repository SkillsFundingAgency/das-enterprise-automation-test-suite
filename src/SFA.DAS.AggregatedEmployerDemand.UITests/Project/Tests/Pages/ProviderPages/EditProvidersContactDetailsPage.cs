using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class EditProvidersContactDetailsPage : AEDBasePage
    {
        protected override string PageTitle => "";
        protected override By PageHeader => By.ClassName("govuk-heading-xl");

        private readonly ScenarioContext _context;
        public EditProvidersContactDetailsPage(ScenarioContext context) : base(context) => _context = context;

        #region Locators
        private By EmailAddressTextBox => By.Id("EmailAddress");
        private By TelephoneNumberTextBox => By.Id("PhoneNumber");
        private By WebsiteTextBox => By.Id("Website");
        #endregion

        public EditProvidersContactDetailsPage EnterProviderEmailAddressDetails(string emailAddress)
        {
            formCompletionHelper.EnterText(EmailAddressTextBox, emailAddress);
            return new EditProvidersContactDetailsPage(_context);
        }
        public EditProvidersContactDetailsPage EnterProviderTelephoneNumberDetails(string telephoneNumber)
        {
            formCompletionHelper.EnterText(TelephoneNumberTextBox, telephoneNumber);
            return new EditProvidersContactDetailsPage(_context);
        }
        public EditProvidersContactDetailsPage EnterProviderWebsiteDetails(string website)
        {
            formCompletionHelper.EnterText(WebsiteTextBox, website);
            return new EditProvidersContactDetailsPage(_context);
        }

        public ConfirmProvidersContactDetailsPage ContinueToConfirmProviderContactDetailsPage()
        {
            ContinueToNextPage();
            return new ConfirmProvidersContactDetailsPage(_context);
        }
    }
}
