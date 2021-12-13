using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class EditProvidersContactDetailsPage : AEDBasePage
    {
        protected override string PageTitle => "";
        protected override By PageHeader => By.ClassName("govuk-heading-xl");

        public EditProvidersContactDetailsPage(ScenarioContext context) : base(context)  { }

        #region Locators
        private By EmailAddressTextBox => By.Id("EmailAddress");
        private By TelephoneNumberTextBox => By.Id("PhoneNumber");
        private By WebsiteTextBox => By.Id("Website");
        private By TelephoneNumberErrorText => By.PartialLinkText("Enter a telephone nu");
        private By EmailAddressErrorText => By.PartialLinkText("Enter an email addre");


        #endregion

        public EditProvidersContactDetailsPage EnterProviderEmailAddressDetails(string emailAddress)
        {
            formCompletionHelper.EnterText(EmailAddressTextBox, emailAddress);
            return new EditProvidersContactDetailsPage(context);
        }
        public EditProvidersContactDetailsPage EnterProviderTelephoneNumberDetails(string telephoneNumber)
        {
            formCompletionHelper.EnterText(TelephoneNumberTextBox, telephoneNumber);
            return new EditProvidersContactDetailsPage(context);
        }
        public EditProvidersContactDetailsPage EnterProviderWebsiteDetails(string website)
        {
            formCompletionHelper.EnterText(WebsiteTextBox, website);
            return new EditProvidersContactDetailsPage(context);
        }

        public ConfirmProvidersContactDetailsPage ContinueToConfirmProviderContactDetailsPage()
        {
            ContinueToNextPage();
            return new ConfirmProvidersContactDetailsPage(context);
        }
        public WhichEmployersAreYouInterestedInPage BackToWhichEmployersAreYouInterestedInPage()
        {
            formCompletionHelper.Click(BackLink);
            return new WhichEmployersAreYouInterestedInPage(context);
        }
        public EditProvidersContactDetailsPage ReEnterProviderTelephoneNumberDetails(string telephoneNumber)
        {
            formCompletionHelper.Click(TelephoneNumberErrorText);
            formCompletionHelper.EnterText(TelephoneNumberTextBox, telephoneNumber);
            return new EditProvidersContactDetailsPage(context);
        }
        public EditProvidersContactDetailsPage ReEnterProviderEmailAddressDetails(string emailAddress)
        {
            formCompletionHelper.Click(EmailAddressErrorText);
            formCompletionHelper.EnterText(EmailAddressTextBox, emailAddress);
            return new EditProvidersContactDetailsPage(context);
        }
    }
}
