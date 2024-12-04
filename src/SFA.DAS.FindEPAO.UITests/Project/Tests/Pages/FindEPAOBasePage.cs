using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public abstract class FindEPAOBasePage : VerifyBasePage
    {
        #region Locators
        protected override By BackLink => By.CssSelector("a.link-back");
        protected override By ContinueButton => By.CssSelector("button.govuk-button[type='submit']");
        protected virtual By FirstResultLink => By.ClassName("das-search-results__link");
        #endregion

        protected FindEPAOBasePage(ScenarioContext context) : base(context) => VerifyPage();

        public void SearchApprenticeshipStandard(string searchTerm)
        {
            new ApprenticeshipTrainningCourseAutoCompleteHelper(context).SelectFromAutoCompleteList(searchTerm);

            Continue();
        }
    }


    public class ApprenticeshipTrainningCourseAutoCompleteHelper(ScenarioContext context) : AutoCompleteHelper(context)
    {
        protected override string SearchPage => "What is the apprenticeship training course?";

        protected override By SearchTextInput => By.CssSelector("input[id='SelectedCourseId']");

        protected override By AutoCompleteMenu => By.CssSelector("[id='SelectedCourseId__listbox']");

        protected override By NthOption(int i) => By.CssSelector($"[id='SelectedCourseId__option--{i}']");
    }
}
