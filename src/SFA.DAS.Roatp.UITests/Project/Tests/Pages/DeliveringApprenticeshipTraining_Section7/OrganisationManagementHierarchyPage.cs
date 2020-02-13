using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class OrganisationManagementHierarchyPage : RoatpBasePage
    {
        protected override string PageTitle => "Who is in your organisation's management hierarchy for apprenticeships?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FullName => By.CssSelector("#FullName");
        private By JobRole => By.CssSelector("#JobRole");
        private By TimeInRoleYears => By.CssSelector("#TimeInRoleYears");
        private By TimeInRoleMonths => By.CssSelector("#TimeInRoleMonths");

        public OrganisationManagementHierarchyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmOrganisationManagementHierarchy EnterDetails()
        {
            formCompletionHelper.EnterText(FullName, applydataHelpers.FullName);
            formCompletionHelper.EnterText(JobRole, applydataHelpers.JobRole);
            formCompletionHelper.EnterText(TimeInRoleYears, applydataHelpers.GenerateRandomWholeNumber(1));
            formCompletionHelper.EnterText(TimeInRoleMonths, applydataHelpers.GenerateRandomWholeNumber(1));
            SelectNoAndContinue();
            return new ConfirmOrganisationManagementHierarchy(_context);
        }
    }
}