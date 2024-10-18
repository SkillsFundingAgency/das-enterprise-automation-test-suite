using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class AutoCompleteHelper
    {
        private readonly ScenarioContext context;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly JavaScriptHelper javaScriptHelper;

        public class ListPopulated : CheckPageUsingLongerTimeOut
        {
            protected override By Identifier => FirstOption;

            public ListPopulated(ScenarioContext context) : base(context) => checkPageInteractionHelper.UpdateTimeSpans(RetryTimeOut.GetTimeSpan([5, 5, 5]));

            public bool IsPageDisplayed(string searchText, Action retryAction) { checkPageInteractionHelper.WaitForElementToChange(FirstOption, AttributeHelper.InnerText, searchText, retryAction); return true; }
        }

        protected AutoCompleteHelper(ScenarioContext context)
        {
            this.context = context;
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            javaScriptHelper = context.Get<JavaScriptHelper>();
            FirstOption = NthOption(0);
        }

        protected abstract string SearchPage { get; }

        protected abstract By SearchTextInput { get; }

        protected abstract By AutoCompleteMenu { get; }

        protected abstract By NthOption(int i);

        public static By FirstOption { get; set; }

        public void SelectFromAutoCompleteList(string searchText)
        {
            string a = string.Empty;

            foreach (var i in searchText)
            {
                a = $"{i}";

                formCompletionHelper.SendKeys(SearchTextInput, a);
            }

            int optionIndex = 0;

            string elementText = string.Empty;

            context.Get<RetryAssertHelper>().RetryOnNUnitException(() =>
            {
                pageInteractionHelper.WaitForElementToChange(AutoCompleteMenu, "class", "autocomplete__menu--visible");

                new ListPopulated(context).IsPageDisplayed(searchText, () => formCompletionHelper.SendKeys(SearchTextInput, $"{Keys.Backspace}{a}"));

                var isAutoCompleteDisplayed = pageInteractionHelper.IsElementDisplayed(FirstOption);

                var autoCompleteList = pageInteractionHelper.GetStringCollectionFromElementsGroup(By.CssSelector(".autocomplete__option")).ToList();

                if (!isAutoCompleteDisplayed && !autoCompleteList.Any(x => x.ContainsCompareCaseInsensitive(searchText)))
                {
                    Assert.Fail($"Auto complete menu for {SearchPage} does not pop up : {searchText}");
                }

                elementText = autoCompleteList.Find(x => x.ContainsCompareCaseInsensitive(searchText));

                optionIndex = autoCompleteList.IndexOf(elementText);

            }, RetryTimeOut.GetTimeSpan([5, 5, 5]));

            By elementselector = NthOption(optionIndex);

            javaScriptHelper.ClickElement(elementselector);

            context.Get<ObjectContext>().SetDebugInformation($"Searched '{searchText}' from auto complete list and selected '{elementText}', using '{elementselector}'");
        }
    }
}
