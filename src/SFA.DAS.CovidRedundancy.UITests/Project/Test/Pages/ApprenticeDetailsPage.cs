using SFA.DAS.CovidRedundancy.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.CovidRedundancy.UITests.Project.Test.Pages
{
    public class ApprenticeDetailsPage : CovidRedundancyBasePage
    {
        protected override string PageTitle => "Apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
