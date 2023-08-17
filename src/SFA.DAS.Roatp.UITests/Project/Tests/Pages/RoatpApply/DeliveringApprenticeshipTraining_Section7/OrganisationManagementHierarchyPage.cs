using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class OrganisationManagementHierarchyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Who is in your organisation's management hierarchy for apprenticeships?";

        private static By FirstName => By.CssSelector("#FirstName");
        private static By LastName => By.CssSelector("#LastName");
        private static By JobRole => By.CssSelector("#JobRole");
        private static By TimeInRoleYears => By.CssSelector("#TimeInRoleYears");
        private static By TimeInRoleMonths => By.CssSelector("#TimeInRoleMonths");
        private static By DateOfBirthMonth => By.CssSelector("#DobMonth");
        private static By DateOfBirthYear => By.CssSelector("#DobYear");
        private static By Email => By.CssSelector("#Email");
        private static By ContactNumber => By.CssSelector("#ContactNumber");

        public OrganisationManagementHierarchyPage(ScenarioContext context) : base(context) => VerifyPage();

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
            return new ConfirmOrganisationManagementHierarchy(context);
        }
    }
}