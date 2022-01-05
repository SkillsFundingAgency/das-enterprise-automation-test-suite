using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class EditProvidersContactDetailsPage : AEDBasePage
    {
        protected override string PageTitle => "Edit";

        protected override bool TakeFullScreenShot => false;

        protected override By PageHeader => By.ClassName("govuk-heading-xl");

        public EditProvidersContactDetailsPage(ScenarioContext context) : base(context)  { }

        #region Locators
        private By EmailAddressTextBox => By.Id("EmailAddress");
        private By TelephoneNumberTextBox => By.Id("PhoneNumber");
        private By WebsiteTextBox => By.Id("Website");

        #endregion

        public EditProvidersContactDetailsPage EnterProvidersContactDetails(string emailAddress, string telephoneNumber, string website)
        {
            formCompletionHelper.EnterText(EmailAddressTextBox, emailAddress);
            formCompletionHelper.EnterText(TelephoneNumberTextBox, telephoneNumber);
            formCompletionHelper.EnterText(WebsiteTextBox, website);
            return this;
        }

        public EditProvidersContactDetailsPage ContinueWithInvalidDetails()
        {
            ContinueToNextPage();
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
    }
}
