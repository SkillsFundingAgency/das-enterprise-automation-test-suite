using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ContactDetailsPage : Raav2BasePage
    {
        protected override string PageTitle => isRaaV2Employer ? $"Contact details for {objectContext.GetEmployerName()} (optional)" : "Do you want to add your contact details?";

        protected By EmployerContactName => By.CssSelector("#EmployerContactName");
        protected By EmployerContactEmail => By.CssSelector("#EmployerContactEmail");
        protected By EmployerContactPhone => By.CssSelector("#EmployerContactPhone");

        protected By ProviderContactName => By.CssSelector("#ProviderContactName");
        protected By ProviderContactEmail => By.CssSelector("#ProviderContactEmail");
        protected By ProviderContactPhone => By.CssSelector("#ProviderContactPhone");

        public ContactDetailsPage(ScenarioContext context) : base(context) { }

        public ApplicationProcessPage EnterProviderContactDetails(bool optionalFields)
        {
            if (optionalFields)
            {
                SelectRadioOptionByForAttribute("contact-details-yes");
                EnterContactDetails();
            }
            else { SelectRadioOptionByForAttribute("contact-details-no"); }

            return GoToApplicationProcessPage();
        }

        public ApplicationProcessPage EnterContactDetailsAndGoToApplicationProcessPage(bool optionalFields)
        {
            if (optionalFields) EnterContactDetails();

            return GoToApplicationProcessPage();
        }

        private void EnterContactDetails()
        {
            formCompletionHelper.EnterText(ContactName(), rAAV2DataHelper.ContactName);
            formCompletionHelper.EnterText(ContactEmail(), rAAV2DataHelper.Email);
            formCompletionHelper.EnterText(ContactPhone(), rAAV2DataHelper.ContactNumber);
        }

        private ApplicationProcessPage GoToApplicationProcessPage()
        {
            Continue();
            return new ApplicationProcessPage(context);
        }

        private By ContactName() => isRaaV2Employer ? EmployerContactName : ProviderContactName;
        private By ContactEmail() => isRaaV2Employer ? EmployerContactEmail : ProviderContactEmail;
        private By ContactPhone() => isRaaV2Employer ? EmployerContactPhone : ProviderContactPhone;
    }
}
