using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers
{
    public class ApprenticeHeleprs
    {
        private readonly ScenarioContext _context;

        public ApprenticeHeleprs(ScenarioContext context) => _context = context;
        internal ApprenticeConfirmationPage CompleteApprenticeForm_HappyPath(NewApprenticeshipLandingPage newApprenticeshipLandingPage)
        {
            newApprenticeshipLandingPage.SelectAprpenticesStartnow()
                .CompleteApprenticeDetails()
                .ConfirmAnswers();
            return new ApprenticeConfirmationPage(_context);
        }
    }
}
