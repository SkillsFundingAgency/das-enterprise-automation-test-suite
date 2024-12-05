using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class SchoolCollegePage(ScenarioContext context, bool verifyPage = true) : EarlyConnectBasePage(context, verifyPage)
    {
        protected override string PageTitle => "What is the name of your school or college?";
        private static By SearchTerm => By.CssSelector("#schoolsearchterm");
        private static By SearchList => By.XPath("//*[contains(@id, 'schoolsearchterm__option')]");
        private static By SchoolManualEntryLink => By.CssSelector("#schoolmanualentry > a");
        private static By ErrorMessage => By.CssSelector("#error-message-SchoolSearchTerm");
        private static new By Continue => By.CssSelector("button[type='submit']");
        private static By SchoolCollegeName => By.CssSelector("#schoolname");
        protected override By ContinueButton => By.CssSelector("#searchschoolsubmit");

        protected void SelectAutoDropDown(string text, bool selectFirstOption = false)
        {
            formCompletionHelper.EnterText(SearchTerm, text);

            context.Get<RetryAssertHelper>().RetryOnNUnitException(() =>
            {
                if (pageInteractionHelper.FindElements(SearchList).Count <= 1)
                {
                    Assert.Fail($"Auto pop up not found for text : {text}");
                }

            }, RetryTimeOut.GetTimeSpan([10, 5, 5, 5]));

            formCompletionHelper.ClickElement(() =>
            {
                var element = selectFirstOption
                    ? pageInteractionHelper.FindElements(SearchList).First()
                    : RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(SearchList));

                SetDebugInformation($"Clicked an auto dropdown element : '{element?.Text}'");

                return element;
            });
        }
        public ApprenticeshipsLevelPage SearchValidSchoolOrCollegeName()
        {
            SelectAutoDropDown(earlyConnectDataHelper.SearchSchoolCollege, true);
            formCompletionHelper.ClickElement(ContinueButton);
            return new ApprenticeshipsLevelPage(context);
        }

        public ApprenticeshipsLevelPage EnterInvalidSchoolOrCollegeName()
        {
            formCompletionHelper.EnterText(SearchTerm, earlyConnectDataHelper.SearchInvalidSchoolCollege);
            formCompletionHelper.ClickElement(ContinueButton);

            if (pageInteractionHelper.IsElementPresent(ErrorMessage))
            {
                formCompletionHelper.Click(SchoolManualEntryLink);
                formCompletionHelper.EnterText(SchoolCollegeName, earlyConnectDataHelper.SchoolCollege);
                formCompletionHelper.ClickElement(Continue);
            }
            return new ApprenticeshipsLevelPage(context);
        }
    }
}
