using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class SchoolCollegePage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "What is the name of your school or college?";
        private static By SchoolCollegeField => By.CssSelector("#schoolname");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public ApprenticeshipsLevelPage EnterValidSchoolOrCollegeName()
        {
            formCompletionHelper.EnterText(SchoolCollegeField, earlyConnectDataHelper.SchoolCollege);
            formCompletionHelper.ClickElement(ContinueButton);
            return new ApprenticeshipsLevelPage(context);
        }
    }
}
