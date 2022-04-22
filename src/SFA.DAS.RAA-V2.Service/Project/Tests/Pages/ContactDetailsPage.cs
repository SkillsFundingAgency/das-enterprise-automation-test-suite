using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ContactDetailsPage : RAAV2CSSBasePage
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


            Continue();
            return new ApplicationProcessPage(context);
        }

        public ApplicationProcessPage EnterContactDetailsAndGoToApplicationProcessPage(bool optionalFields)
        {
            if (optionalFields)
            {
                formCompletionHelper.EnterText(ContactName(), rAAV2DataHelper.ContactName);
                formCompletionHelper.EnterText(ContactEmail(), rAAV2DataHelper.Email);
                formCompletionHelper.EnterText(ContactPhone(), rAAV2DataHelper.ContactNumber);
            }

            Continue();
            return new ApplicationProcessPage(context);
        }

        public PreviewYouAdvertOrVacancyPage EnterContactDetails()
        {
            formCompletionHelper.EnterText(ContactName(), rAAV2DataHelper.ContactName);
            formCompletionHelper.EnterText(ContactEmail(), rAAV2DataHelper.Email);
            formCompletionHelper.EnterText(ContactPhone(), rAAV2DataHelper.ContactNumber);
            Continue();
            return new PreviewYouAdvertOrVacancyPage(context);
        }

        private By ContactName() => isRaaV2Employer ? EmployerContactName : ProviderContactName;
        private By ContactEmail() => isRaaV2Employer ? EmployerContactEmail : ProviderContactEmail;
        private By ContactPhone() => isRaaV2Employer ? EmployerContactPhone : ProviderContactPhone;
    }
}
