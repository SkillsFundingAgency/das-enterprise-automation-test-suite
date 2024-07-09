using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ContactDetailsPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? $"Contact details for {objectContext.GetEmployerName()} (optional)" : "Do you want to add your contact details?";

        protected static By EmployerContactName => By.CssSelector("#EmployerContactName");
        protected static By EmployerContactEmail => By.CssSelector("#EmployerContactEmail");
        protected static By EmployerContactPhone => By.CssSelector("#EmployerContactPhone");

        protected static By ProviderContactName => By.CssSelector("#ProviderContactName");
        protected static By ProviderContactEmail => By.CssSelector("#ProviderContactEmail");
        protected static By ProviderContactPhone => By.CssSelector("#ProviderContactPhone");

        public ApplicationProcessPage EnterProviderContactDetails(bool optionalFields)
        {
            EnterProviderDetails(optionalFields);

            return GoToApplicationProcessPage();
        }

        public ApplicationProcessPage EnterContactDetailsAndGoToApplicationProcessPage(bool optionalFields)
        {
            if (optionalFields) EnterContactDetails();

            return GoToApplicationProcessPage();
        }

        private void EnterProviderDetails(bool optionalFields)
        {
            if (optionalFields)
            {
                SelectRadioOptionByForAttribute("contact-details-yes");
                EnterContactDetails();
            }
            else
            {
                SelectRadioOptionByForAttribute("contact-details-no");
            }
        }

        private void EnterContactDetails()
        {
            formCompletionHelper.EnterText(ContactName(), rAADataHelper.ContactName);
            formCompletionHelper.EnterText(ContactEmail(), rAADataHelper.Email);
            formCompletionHelper.EnterText(ContactPhone(), RAADataHelper.ContactNumber);
        }

        private ApplicationProcessPage GoToApplicationProcessPage()
        {
            Continue();
            return new ApplicationProcessPage(context);
        }

        private By ContactName() => isRaaEmployer ? EmployerContactName : ProviderContactName;
        private By ContactEmail() => isRaaEmployer ? EmployerContactEmail : ProviderContactEmail;
        private By ContactPhone() => isRaaEmployer ? EmployerContactPhone : ProviderContactPhone;
    }
}
