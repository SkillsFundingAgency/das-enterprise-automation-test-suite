using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class MostExperiencedEmployeePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Who's the most experienced employee";

        protected static By LabelCssSelector => By.CssSelector(".govuk-form-group");
        protected static By MontYearCssSelector => By.CssSelector(".govuk-form-group .govuk-form-group");


        public MostExperiencedEmployeePage(ScenarioContext context) : base(context) => VerifyPage();

        public ExperienceInTheSectorPage EnterDetails()
        {
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "First name", RoatpApplyDataHelpers.FirstName);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Last name", RoatpApplyDataHelpers.LastName);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Job role", RoatpApplyDataHelpers.JobRole);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Time in role", $"{RoatpApplyDataHelpers.GenerateRandomWholeNumber(1)} years, {RoatpApplyDataHelpers.GenerateRandomWholeNumber(1)} months");
            formCompletionHelper.EnterTextByLabel(MontYearCssSelector, "Month", "12");
            formCompletionHelper.EnterTextByLabel(MontYearCssSelector, "Year", "1989");
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Email", RoatpApplyDataHelpers.Email);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Contact number", RoatpApplyDataHelpers.ContactNumber);
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.NamesOfAllOrganisations);
            return new ExperienceInTheSectorPage(context);
        }
    }
}