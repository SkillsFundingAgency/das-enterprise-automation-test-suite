using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class StaffDashboardPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Staff dashboard";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By NewOrganisationApplication => By.CssSelector("a.govuk-link[href='/OrganisationApplication#new']");
        private By InProgressOrganisationApplication => By.CssSelector("a.govuk-link[href='/OrganisationApplication#in-progress']");
        private By ApprovedOrganisationApplication => By.CssSelector("a.govuk-link[href='/OrganisationApplication#approved']");

        private By NewStandardApplication => By.CssSelector("a.govuk-link[href='/StandardApplication#new']");

        private By NewWithdrawalApplications => By.CssSelector("a.govuk-link[href='/WithdrawalApplication#new']");
        private By InProgressWithdrawalApplications => By.CssSelector("a.govuk-link[href='/WithdrawalApplication#in-progress']");
        private By InProgressStandardApplication => By.CssSelector("a.govuk-link[href='/StandardApplication#in-progress']");
        private By FeedbackWithdrawalApplications => By.CssSelector("a.govuk-link[href='/WithdrawalApplication#feedback']");
        private By ApprovedStandardApplication => By.CssSelector("a.govuk-link[href='/StandardApplication#approved']");


        private By NewFinancialHeathAssesment => By.CssSelector("a.govuk-link[href='/Financial/Open']");
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

        public OrganisationApplicationsPage GoToNewOrganisationApplications()
        {
            formCompletionHelper.ClickElement(NewOrganisationApplication);
            return new OrganisationApplicationsPage(_context);
        }

        public OrganisationApplicationsPage GoToInProgressOrganisationApplication()
        {
            formCompletionHelper.ClickElement(InProgressOrganisationApplication);
            return new OrganisationApplicationsPage(_context);
        }

        public OrganisationApplicationsPage GoToApprovedOrganisationApplication()
        {
            formCompletionHelper.ClickElement(ApprovedOrganisationApplication);
            return new OrganisationApplicationsPage(_context);
        }

        public FinancialAssesmentPage GoToNewFinancialAssesmentPage()
        {
            formCompletionHelper.ClickElement(NewFinancialHeathAssesment);
            return new FinancialAssesmentPage(_context);
        }

        public StandardApplicationsPage GoToNewStandardApplications()
        {
            formCompletionHelper.ClickElement(NewStandardApplication);
            return new StandardApplicationsPage(_context);
        }

        public StandardApplicationsPage GoToInProgressStandardApplication()
        {
            formCompletionHelper.ClickElement(InProgressStandardApplication);
            return new StandardApplicationsPage(_context);
        }

        public AD_WithdrawalApplicationsPage GoToNewWithdrawalApplications()
        {
            formCompletionHelper.ClickElement(NewWithdrawalApplications);
            return new AD_WithdrawalApplicationsPage(_context);
        }

        public AD_WithdrawalApplicationsPage GoToFeedbackWithdrawalApplications()
        {
            formCompletionHelper.ClickElement(FeedbackWithdrawalApplications);
            return new AD_WithdrawalApplicationsPage(_context);
        }
    }
}