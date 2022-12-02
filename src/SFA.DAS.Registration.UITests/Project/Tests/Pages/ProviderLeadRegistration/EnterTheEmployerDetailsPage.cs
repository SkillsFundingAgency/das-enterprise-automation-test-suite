using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class EnterTheEmployerDetailsPage : ProviderLeadRegistrationBasePage
    {
        protected override string PageTitle => "Enter the employer details";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");
        
        private By EmailCannotBeEditedWarning = By.CssSelector(".govuk-inset-text p");

        private By FormGroup = By.CssSelector(".govuk-form-group");

        private By EmployerOrganisation(string value = null) => By.CssSelector($"#EmployerOrganisation{value}");

        private By EmployerFirstName(string value = null) => By.CssSelector($"#EmployerFirstName{value}");

        private By EmployerLastName(string value = null) => By.CssSelector($"#EmployerLastName{value}");

        private By EmployerEmailAddress(string value = null) => By.CssSelector($"#EmployerEmailAddress{value}");

        private string OrganisationName => registrationDataHelper.CompanyTypeOrg;
        private string FirstName => registrationDataHelper.FirstName;
        private string LastName => registrationDataHelper.LastName;
        private readonly string Email;
        
        public EnterTheEmployerDetailsPage(ScenarioContext context): base(context)
        {
            Email = objectContext.GetRegisteredEmail();
        }

        public CheckDetailsPage EnterRegistrationDetailsAndContinue()
        {
            formCompletionHelper.EnterText(EmployerOrganisation(), OrganisationName);
            formCompletionHelper.EnterText(EmployerFirstName(), FirstName);
            formCompletionHelper.EnterText(EmployerLastName(), LastName);
            formCompletionHelper.EnterText(EmployerEmailAddress(), Email);
            return NavigateToCheckDetailsPage();
        }

        public CheckDetailsPage UpdateEmployerFirstNameAndContinue(string newFirstName)
        {
            registrationDataHelper.FirstName = newFirstName;
            formCompletionHelper.EnterText(EmployerFirstName(), FirstName);
            return NavigateToCheckDetailsPage();
        }

        public EnterTheEmployerDetailsPage VerifyDetails()
        {
            pageInteractionHelper.VerifyPage(EmployerOrganisation($"[value='{OrganisationName}']"));
            pageInteractionHelper.VerifyPage(EmployerFirstName($"[value='{FirstName}']"));
            pageInteractionHelper.VerifyPage(EmployerLastName($"[value='{LastName}']"));
            pageInteractionHelper.VerifyPage(EmployerEmailAddress($"[value='{Email}']"));
            return this;
        }

        public CheckDetailsPage NavigateToCheckDetailsPage()
        {
            Continue();
            return new CheckDetailsPage(context);
        }

        public EnterTheEmployerDetailsPage VerifyEmailIsNotEditable()
        {
            var emailFormGroup = pageInteractionHelper
                .FindElements(FormGroup)
                .SingleOrDefault(p => p.FindElement(By.CssSelector(".govuk-label")).Text == "Employer email address");
            Assert.IsNotNull(emailFormGroup, "The 'Employer email address' form group cannot be found'");

            var emailInsetText = emailFormGroup.FindElement(By.CssSelector(".govuk-inset-text"));
            Assert.IsNotNull(emailInsetText, "The 'Employer email address' form group does not contain inset text");

            var paragraphs = emailInsetText.FindElements(By.CssSelector("p"));
            Assert.IsTrue(paragraphs.Any(p => p.Text == "This cannot be changed for an email re-send"), "Email read only text cannot be found");
            Assert.IsTrue(paragraphs.Any(p => p.Text == $"{Email.ToLower()}"), "Email read only value cannot be found");

            return this;
        }
    }
}