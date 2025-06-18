using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class WhoIsInControlOfYourOrganisationPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Who is in control of your organisation?";

        private static By FullNameField => By.Id("PersonInControlName");
        private static By MonthField => By.CssSelector("#PersonInControlDobMonth");
        private static By YearField => By.CssSelector("#PersonInControlDobYear");

        public WhoIsInControlOfYourOrganisationPage(ScenarioContext context) : base(context) => VerifyPage();

        public ConfrimWhosInControlPage EnterWhoIsInControlDetailsAndContinue()
        {
            formCompletionHelper.EnterText(FullNameField, RoatpApplyDataHelpers.FullName);
            var dobcalc = Helpers.DataHelpers.RoatpApplyDataHelpers.Dob(2);
            formCompletionHelper.EnterText(MonthField, dobcalc.Month);
            formCompletionHelper.EnterText(YearField, dobcalc.Year);
            Continue();
            return new ConfrimWhosInControlPage(context);
        }
    }
}