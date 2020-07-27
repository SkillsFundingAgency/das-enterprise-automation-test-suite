using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.EmployerDetails;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers
{
    public class EmployerHelper
    {
        private readonly ScenarioContext _context;

        public EmployerHelper(ScenarioContext context) => _context = context;
        internal EmployerConfirmationPage CompleteEmployerForm_HappyPath(MainLandingPage mainLandingPage)
        {
            mainLandingPage.NavigateToFindApprentices()
             .SelectEmployerStartnow()
                 .CompleteEmployersDetails()
                 .ConfirmEmployerAnswers();
            return new EmployerConfirmationPage(_context);
        }
        internal EmployerDetailsPage ContinueWithoutAllMandatoryFieldsCompletedForEmployerForm(MainLandingPage mainLandingPage)
        {
            mainLandingPage.NavigateToFindApprentices()
             .SelectEmployerStartnow()
             .ContinueToEmployerCheckAnswersPage();
            return new EmployerDetailsPage(_context);
        }
    }
}
