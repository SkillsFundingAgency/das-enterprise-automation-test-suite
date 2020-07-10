using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers
{
    public class ApprenticeHelper
    {
        private readonly ScenarioContext _context;

        public ApprenticeHelper(ScenarioContext context) => _context = context;
        internal ApprenticeConfirmationPage CompleteApprenticeForm_HappyPath(MainLandingPage mainLandingPage)
        {
           mainLandingPage.NavigateToFindAnotherApprenticeship()
            .SelectAprpenticesStartnow()
                .CompleteApprenticeDetails()
                .ConfirmApprenticeAnswers();
            return new ApprenticeConfirmationPage(_context);
        }
    }
}
