using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class SchoolCollegePage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "What is the name of your school or college?";
        private static By SearchSchoolCollegeField => By.CssSelector("#schoolsearchterm");
        private static By SchoolManualEntryLink => By.CssSelector("#schoolmanualentry > a"); 
        protected override By ContinueButton => By.CssSelector("searchschoolsubmit");//button[type='submit'

        public ApprenticeshipsLevelPage EnterValidSchoolOrCollegeName()
        {

            formCompletionHelper.EnterText(SearchSchoolCollegeField, earlyConnectDataHelper.SearchSchoolCollege);
            formCompletionHelper.ClickElement(ContinueButton);
            return new ApprenticeshipsLevelPage(context);
        }
    }
}
