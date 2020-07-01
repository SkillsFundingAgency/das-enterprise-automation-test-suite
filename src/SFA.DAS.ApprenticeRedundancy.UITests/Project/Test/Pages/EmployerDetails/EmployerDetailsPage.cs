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
        protected override string PageTitle => "Employer details";

        private By OrganisationName = By.Id("OrganisationName");
        private By ContactName = By.Id("ContactName");
        private By Email = By.Id("Email");
        private By PhoneNumber = By.Id("PhoneNumber");
        private By Wwbstite = By.Id("Website");

        #region Helpers and Context  
        private readonly ScenarioContext _context;
        #endregion

        public EmployerDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        //public Employer_CheckYourAnswersPage CompleteEmployersDetails()
        //{
        //    formCompletionHelper.EnterText()
        //    return new Employer_CheckYourAnswersPage(_context);
        //}
    }
}
