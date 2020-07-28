using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.EmployerDetails
{
   public class Employer_CheckYourAnswersPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "Check your answers";

        private By OrganisationDetails => By.XPath("//div[@class='das-check-section']//span[text()=' organisation details']");
        private By Locations => By.XPath("//div[@class='das-check-section']//span[text()=' apprenticeship locations']");
        private By ApprenticeshipDetails => By.XPath("//div[@class='das-check-section']//span[text()=' apprenticeship details']");
        private By Contact => By.XPath("//div[@class='das-check-section']//span[text()=' how can we contact you?']");
        private By ContactNameText => By.XPath("(//dd[@class='govuk-summary-list__value'])[7]");
        private By PhoneNumberText => By.XPath("(//dd[@class='govuk-summary-list__value'])[8]");
        private By FeedbackText => By.XPath("(//dd[@class='govuk-summary-list__value'])[9]");


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public Employer_CheckYourAnswersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public EmployerConfirmationPage ConfirmEmployerAnswers()
        {
            Continue();
            return new EmployerConfirmationPage(_context);
        }
        public EmployerDetailsPage ClickChangeOrganisationDetailsLink()
        {
            formCompletionHelper.ClickElement(OrganisationDetails);
            return new EmployerDetailsPage(_context);
        }
        public EmployerDetailsPage ClickChangeApprenticeLocationsLink()
        {
            formCompletionHelper.ClickElement(Locations);
            return new EmployerDetailsPage(_context);
        }
        public EmployerDetailsPage ClickChangeApprenticeshipDetailsLink()
        {
            formCompletionHelper.ClickElement(ApprenticeshipDetails);
            return new EmployerDetailsPage(_context);
        }
        public EmployerDetailsPage ClickChangeContactDetailsLink()
        {
            formCompletionHelper.ClickElement(Contact);
            return new EmployerDetailsPage(_context);
        }
        public Employer_CheckYourAnswersPage VerifyUpdatedContactDetails (string contactName)
        {
            pageInteractionHelper.VerifyText(ContactNameText, contactName);
            return this;
        }
        public Employer_CheckYourAnswersPage VerifyUpdatedContactNumber (string contactNumber)
        {
            pageInteractionHelper.VerifyText(PhoneNumberText, contactNumber);
            return this;
        }
        public Employer_CheckYourAnswersPage VerifyUpdateSelectionForFeedback(string feedback)
        {
            pageInteractionHelper.VerifyText(FeedbackText, feedback);
            return this;
        }
    }
}

