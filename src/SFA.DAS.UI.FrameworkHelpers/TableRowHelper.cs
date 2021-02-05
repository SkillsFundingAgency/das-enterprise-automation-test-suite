using OpenQA.Selenium;
using System;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class TableRowHelper 
    {
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly RegexHelper _regexHelper;

        public TableRowHelper(PageInteractionHelper pageInteractionHelper, FormCompletionHelper formCompletionHelper, RegexHelper regexHelper)
        {
            _formCompletionHelper = formCompletionHelper;
            _pageInteractionHelper = pageInteractionHelper;
            _regexHelper = regexHelper;
        }

        public IWebElement GetColumn(string rowIdentifier, By columnIdentifier, string tableSelector = "table", string tableRowSelector = "tbody tr")
        {
            var table = _pageInteractionHelper.FindElements(By.CssSelector(tableSelector)).FirstOrDefault(x => x.Enabled && x.Displayed);
            var tableRows = table.FindElements(By.CssSelector(tableRowSelector));

            foreach (var tablerow in tableRows)
            {
                if (tablerow.Text.ContainsCompareCaseInsensitive(rowIdentifier) && tablerow.FindElements(columnIdentifier).Any())
                {
                   return tablerow.FindElement(columnIdentifier);
                }
            }
            throw new Exception($"Test Exception: Could not find row with text '{rowIdentifier}' or column using '{columnIdentifier}' and selector '{tableSelector}'");
        }


        public void SelectRowFromTable(string byLinkText, string byKey, string tableSelector = "table")
        {
            var element = FindElementInTable(byLinkText, byKey, tableSelector);

            _formCompletionHelper.ClickElement(element);
        }

        public IWebElement FindElementInTable(string byLinkText, string byKey, string tableSelector = "table")
        {
            var table = _pageInteractionHelper.FindElement(By.CssSelector(tableSelector));
            var tableRows = table.FindElements(By.CssSelector("tbody tr"));
            var links = _pageInteractionHelper.FindElements(By.PartialLinkText(byLinkText));
            int i = 0;
            foreach (IWebElement tableRow in tableRows)
            {
                if (tableRow.Text.Contains(byKey))
                {
                    return links[i];
                }
                i++;
            }
            throw new System.Exception($"Test Exception: Could not find link with text '{byLinkText}' using key '{byKey}' and selector '{tableSelector}'");
        }

        public void SelectRowFromTableDescending(string byLinkText, string byKey, string tableSelector = "table")
        {
            var table = _pageInteractionHelper.FindElement(By.CssSelector(tableSelector));
            var tableRows = table.FindElements(By.CssSelector("tbody tr")).Reverse();
            var links = _pageInteractionHelper.FindElements(By.PartialLinkText(byLinkText));
            int i = tableRows.Count()-1;
            foreach (IWebElement tableRow in tableRows)
            {
                if (tableRow.Text.Contains(byKey))
                {
                    _formCompletionHelper.ClickElement(links[i]);
                    return;
                }
                i--;
            }
            throw new System.Exception($"Test Exception: Could not find link with text '{byLinkText}' using key '{byKey}' and selector '{tableSelector}'");
        }

        public void SelectRowFromTable(string byLinkText, string byKey, By nextPage, By noOfPages, string tableSelector = "table")
        {
             if (_pageInteractionHelper.IsElementDisplayed(nextPage))
            {
                int NoOfpages = _regexHelper.GetMaxNoOfPages(_pageInteractionHelper.GetText(noOfPages));

                for (int i = 1; i <= NoOfpages - 1; i++)
                {
                    try
                    {
                        SelectRowFromTable(byLinkText, byKey, tableSelector);
                        return;
                    }
                    catch (System.Exception)
                    {
                        _formCompletionHelper.ClickElement(nextPage);
                    }
                }
            }

            SelectRowFromTable(byLinkText, byKey, tableSelector);
        }
    }
}
