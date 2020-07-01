using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.EmployerDetails
{
   public class Employer_CheckYourAnswersPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "Check your answers";
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public Employer_CheckYourAnswersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public EmployerConfirmationPage ConfirmAnswers()
        {
            Continue();
            return new EmployerConfirmationPage(_context);
        }
    }
}

