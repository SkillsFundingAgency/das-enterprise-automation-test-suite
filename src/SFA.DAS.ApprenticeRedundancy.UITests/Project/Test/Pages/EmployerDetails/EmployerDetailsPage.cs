using OpenQA.Selenium;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.Apprentice;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.EmployerDetails
{
    public class EmployerDetailsPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "Tell us about your apprenticeship opportunity";

        #region Element Locators
        private By OrganisationName = By.Id("OrganisationName");
        private By ContactFirstName = By.Id("ContactFirstName");
        private By ContactLastName = By.Id("ContactLastName");
        private By Email = By.Id("Email");
        private By PhoneNumber = By.Id("PhoneNumber");
        private By Locations = By.CssSelector(".govuk-checkboxes__item");
        private By MoreDetail = By.Id("ApprenticeshipMoreDetails");
        private By FeedbackYes = By.Id("ContactableForFeedback");
        private By FeedbackNo = By.Id("ContactableForFeedback-no");
        private By HealthAndScience = By.Id("Sectors-11");
        private By ProtectiveServices = By.Id("Sectors-13");
        private By TransportLogistics = By.Id("Sectors-15");
        #endregion

        #region Helpers and Context  
        private readonly ScenarioContext _context;
        #endregion

        public EmployerDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public Employer_CheckYourAnswersPage CompleteEmployersDetails()
        {
            formCompletionHelper.EnterText(OrganisationName, apprenticeRedundancyDataHelper.OrganisationName);
            formCompletionHelper.SelectCheckBoxByText(Locations, "North West");
            formCompletionHelper.SelectCheckBoxByText(Locations, "West Midlands");
            formCompletionHelper.SelectCheckBoxByText(Locations, "Yorkshire and the Humber");
            formCompletionHelper.SelectCheckbox(HealthAndScience);
            formCompletionHelper.SelectCheckbox(ProtectiveServices);
            formCompletionHelper.SelectCheckbox(TransportLogistics);
            formCompletionHelper.EnterText(MoreDetail, apprenticeRedundancyDataHelper.LongText);
            formCompletionHelper.EnterText(ContactFirstName, apprenticeRedundancyDataHelper.FirstName);
            formCompletionHelper.EnterText(ContactLastName, apprenticeRedundancyDataHelper.LastName);
            formCompletionHelper.EnterText(Email, apprenticeRedundancyDataHelper.Email);
            formCompletionHelper.EnterText(PhoneNumber, apprenticeRedundancyDataHelper.ContactNumber);
            formCompletionHelper.SelectRadioOptionByLocator( FeedbackYes );
            Continue();
            return new Employer_CheckYourAnswersPage(_context);
        }

        public EmployerDetailsPage ContinueToEmployerCheckAnswersPage()
        {
            Continue();
            return this;
        }
        public Employer_CheckYourAnswersPage NavigateBackToEmployerCheckYourAnswersPage()
        {
            NavigateBack();
            return new Employer_CheckYourAnswersPage(_context);
        }
        public Employer_CheckYourAnswersPage UpdateContactDetails()
        {
            formCompletionHelper.EnterText(ContactFirstName, apprenticeRedundancyDataHelper.UpdatedFirstName);
            formCompletionHelper.EnterText(ContactLastName, apprenticeRedundancyDataHelper.UpdatedLastName);
            formCompletionHelper.EnterText(PhoneNumber, apprenticeRedundancyDataHelper.UpdatedContactNumber);
            formCompletionHelper.SelectRadioOptionByLocator(FeedbackNo);
            Continue();
            return new Employer_CheckYourAnswersPage(_context);
        }
    }
}
