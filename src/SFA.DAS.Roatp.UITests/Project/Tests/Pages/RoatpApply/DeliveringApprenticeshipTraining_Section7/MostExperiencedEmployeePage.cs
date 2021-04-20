using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class MostExperiencedEmployeePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Who's the most experienced employee";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        
        protected By LabelCssSelector => By.CssSelector(".govuk-form-group");
        protected By MontYearCssSelector => By.CssSelector(".govuk-form-group .govuk-form-group");
     

        public MostExperiencedEmployeePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ExperienceInTheSectorPage EnterDetails()
        {
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "First name", applydataHelpers.FirstName);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Last name", applydataHelpers.LastName);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Job role", applydataHelpers.JobRole);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Time in role", $"{applydataHelpers.GenerateRandomWholeNumber(1)} years, {applydataHelpers.GenerateRandomWholeNumber(1)} months");
            formCompletionHelper.EnterTextByLabel(MontYearCssSelector, "Month", "12" );
            formCompletionHelper.EnterTextByLabel(MontYearCssSelector, "Year", "1989");
            formCompletionHelper.EnterTextByLabel(LabelCssSelector,"Email", applydataHelpers.Email);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector,"Contact number", applydataHelpers.ContactNumber);
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.NamesOfAllOrganisations);
            return new ExperienceInTheSectorPage(_context);
        }
    }
}