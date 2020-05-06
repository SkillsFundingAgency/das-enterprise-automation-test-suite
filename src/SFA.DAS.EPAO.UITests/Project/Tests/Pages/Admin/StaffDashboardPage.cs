using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class StaffDashboardPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Staff dashboard";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By SearchLink => By.CssSelector("a.govuk-link[href='/Search']");
        private By BatchSearch => By.CssSelector("a.govuk-link[href='/BatchSearch']");
        private By Register => By.CssSelector("a.govuk-link[href='/Register']");
        private By AddOrganisationLink => By.CssSelector("a.govuk-link[href='/register/add-organisation']");
        private By ScheduleConfig => By.CssSelector("a.govuk-link[href='/ScheduleConfig']");
        private By Reports => By.CssSelector("a.govuk-link[href='/Reports']");
        private By CertificateApprovals => By.CssSelector("a.govuk-link[href='/CertificateApprovals/New']");
        private By ExternalApi => By.CssSelector("a.govuk-link[href='/ExternalApi']");
        private By Financial => By.CssSelector("a.govuk-link[href='/Financial/Open']");
        private By Applications => By.CssSelector("a.govuk-link[href='/Applications/Midpoint']");

        public StaffDashboardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public SearchPage Search()
        {
            formCompletionHelper.ClickElement(SearchLink);
            return new SearchPage(_context);
        }

        public OrganisationSearchPage SearchEPAO()
        {
            formCompletionHelper.ClickElement(Register);
            return new OrganisationSearchPage(_context);
        }

        public AddOrganisationPage AddOrganisation()
        {
            formCompletionHelper.ClickElement(AddOrganisationLink);
            return new AddOrganisationPage(_context);
        }

        public BatchSearchPage SearchEPAOBatch()
        {
            formCompletionHelper.ClickElement(BatchSearch);
            return new BatchSearchPage(_context);
        }
    }
}

