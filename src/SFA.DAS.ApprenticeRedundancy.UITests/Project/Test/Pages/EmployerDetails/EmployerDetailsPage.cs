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

        private By OrganisationName = By.Id("OrganisationName");
        private By ContactFirstName = By.Id("ContactFirstName");
        private By ContactLastName = By.Id("ContactLastName");
        private By Email = By.Id("Email");
        private By PhoneNumber = By.Id("PhoneNumber");
        private By Webstite = By.Id("Website");
        private By LocationAndSectors = By.CssSelector(".govuk-checkboxes__item");
        private By MoreDetail = By.Id("ApprenticeshipMoreDetails");
        private By FeedbackYes = By.Id("ContactableForFeedback");

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
            formCompletionHelper.EnterText(Email, apprenticeRedundancyDataHelper.Email);
            formCompletionHelper.EnterText(Webstite, apprenticeRedundancyDataHelper.Website);
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "North West");
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "West Midlands");
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "Yorkshire and the Humber");
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "Health and science");
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "Protective services");
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "Transport and logistics");
            formCompletionHelper.EnterText(MoreDetail, apprenticeRedundancyDataHelper.LongText);
            formCompletionHelper.EnterText(ContactFirstName, apprenticeRedundancyDataHelper.FirstName);
            formCompletionHelper.EnterText(ContactLastName, apprenticeRedundancyDataHelper.LastName);
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
    }
}
