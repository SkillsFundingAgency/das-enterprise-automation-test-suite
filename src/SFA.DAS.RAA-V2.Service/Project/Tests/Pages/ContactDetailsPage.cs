using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ContactDetailsPage : Raav2BasePage
    {
        protected override string PageTitle => isRaaV2Employer ? $"Contact details for {objectContext.GetEmployerName()} (optional)" : "Do you want to add your contact details?";

        protected static By EmployerContactName => By.CssSelector("#EmployerContactName");
        protected static By EmployerContactEmail => By.CssSelector("#EmployerContactEmail");
        protected static By EmployerContactPhone => By.CssSelector("#EmployerContactPhone");

        protected static By ProviderContactName => By.CssSelector("#ProviderContactName");
        protected static By ProviderContactEmail => By.CssSelector("#ProviderContactEmail");
        protected static By ProviderContactPhone => By.CssSelector("#ProviderContactPhone");

        public ContactDetailsPage(ScenarioContext context) : base(context) { }

        public ApplicationProcessPage EnterProviderContactDetails(bool optionalFields)
        {
            EnterProviderDetails(optionalFields);

            return GoToApplicationProcessPage();
        }

        public CheckYourAnswersPage EnterProviderContactDetailsTraineeship(bool optionalFields)
        {
            EnterProviderDetails(optionalFields);

            return GoToCheckYourAnswersPage();
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
            formCompletionHelper.EnterText(ContactName(), rAAV2DataHelper.ContactName);
            formCompletionHelper.EnterText(ContactEmail(), rAAV2DataHelper.Email);
            formCompletionHelper.EnterText(ContactPhone(), RAAV2DataHelper.ContactNumber);
        }

        private ApplicationProcessPage GoToApplicationProcessPage()
        {
            Continue();
            return new ApplicationProcessPage(context);
        }
        
        private CheckYourAnswersPage GoToCheckYourAnswersPage()
        {
            Continue();
            return new CheckYourAnswersPage(context);
        }

        private By ContactName() => isRaaV2Employer ? EmployerContactName : ProviderContactName;
        private By ContactEmail() => isRaaV2Employer ? EmployerContactEmail : ProviderContactEmail;
        private By ContactPhone() => isRaaV2Employer ? EmployerContactPhone : ProviderContactPhone;
    }
}
