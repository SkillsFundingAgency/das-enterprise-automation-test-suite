using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class OrganisationManagementHierarchyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Who is in your organisation's management hierarchy for apprenticeships?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FirstName => By.CssSelector("#FirstName");
        private By LastName => By.CssSelector("#LastName");
        private By JobRole => By.CssSelector("#JobRole");
        private By TimeInRoleYears => By.CssSelector("#TimeInRoleYears");
        private By TimeInRoleMonths => By.CssSelector("#TimeInRoleMonths");
        private By DateOfBirthMonth => By.CssSelector("#DobMonth");
        private By DateOfBirthYear => By.CssSelector("#DobYear");
        private By Email => By.CssSelector("#Email");
        public By ContactNumber => By.CssSelector("#ContactNumber");

        public OrganisationManagementHierarchyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmOrganisationManagementHierarchy EnterDetails()
        {
            formCompletionHelper.EnterText(FirstName, applydataHelpers.FirstName);
            formCompletionHelper.EnterText(LastName, applydataHelpers.LastName);
            formCompletionHelper.EnterText(JobRole, applydataHelpers.JobRole);
            formCompletionHelper.EnterText(TimeInRoleYears, applydataHelpers.GenerateRandomWholeNumber(1));
            formCompletionHelper.EnterText(TimeInRoleMonths, applydataHelpers.GenerateRandomWholeNumber(1));
            formCompletionHelper.EnterText(DateOfBirthMonth, applydataHelpers.RandomMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, applydataHelpers.RandomYear);
            formCompletionHelper.EnterText(Email, applydataHelpers.Email);
            formCompletionHelper.EnterText(ContactNumber, applydataHelpers.ContactNumber);
            SelectNoAndContinue();
            return new ConfirmOrganisationManagementHierarchy(_context);
        }
    }
}