using OpenQA.Selenium;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.EmployerDetails;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages
{
    public class MainLandingPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "Page not found";

        private By EmployerAndApprenticeLinks => By.CssSelector(".govuk-link");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public MainLandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public NewApprenticeshipLandingPage NavigateToFindAnotherApprenticeship()
        {
            formCompletionHelper.ClickLinkByText(EmployerAndApprenticeLinks, "find another apprenticeship if you've been made redundant");
            return new NewApprenticeshipLandingPage(_context);
        }
        public NewEmployerLandingPage NavigateToFindApprentices()
        {
            formCompletionHelper.ClickLinkByText(EmployerAndApprenticeLinks, "find apprentices who have been made redundant");
            return new NewEmployerLandingPage(_context);
        }
    }
}
