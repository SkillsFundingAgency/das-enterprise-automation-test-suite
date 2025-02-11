using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class SchoolCollegePage(ScenarioContext context, bool verifyPage = true) : EarlyConnectBasePage(context, verifyPage)
    {
        protected override string PageTitle => "What is the name of your school or college?";
        private static By SearchTerm => By.CssSelector("#schoolsearchterm");
        private static By SchoolManualEntryLink => By.CssSelector("#schoolmanualentry > a");
        private static By ErrorMessage => By.CssSelector("#error-message-SchoolSearchTerm");
        private static new By Continue => By.CssSelector("button[type='submit']");
        private static By SchoolCollegeName => By.CssSelector("#schoolname");
        protected override By ContinueButton => By.CssSelector("#searchschoolsubmit");

        public ApprenticeshipsLevelPage SearchValidSchoolOrCollegeName()
        {
            new ApprenticeshipAdviserSchoolAutoCompleteHelper(context).SelectFromAutoCompleteList(earlyConnectDataHelper.SchoolOrCollegeName);

            Continue();

            return new ApprenticeshipsLevelPage(context);
        }

        public ApprenticeshipsLevelPage EnterInvalidSchoolOrCollegeName()
        {
            formCompletionHelper.EnterText(SearchTerm, earlyConnectDataHelper.SearchInvalidSchoolCollege);
            formCompletionHelper.ClickElement(ContinueButton);

            if (pageInteractionHelper.IsElementPresent(ErrorMessage))
            {
                formCompletionHelper.Click(SchoolManualEntryLink);
                formCompletionHelper.EnterText(SchoolCollegeName, $"{earlyConnectDataHelper.SchoolOrCollegeName} school or college manual entry");
                formCompletionHelper.ClickElement(Continue);
            }
            return new ApprenticeshipsLevelPage(context);
        }
    }

    public class ApprenticeshipAdviserSchoolAutoCompleteHelper(ScenarioContext context) : AutoCompleteHelper(context)
    {
        protected override string SearchPage => "What is the name of your school or college?";

        protected override By SearchTextInput => By.CssSelector("input[id='schoolsearchterm']");

        protected override By AutoCompleteMenu => By.CssSelector("[id='schoolsearchterm__listbox']");

        protected override By NthOption(int i) => By.CssSelector($"[id='schoolsearchterm__option--{i}']");
    }
}
