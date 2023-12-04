using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers;

public class TableRowHelper 
{
    private readonly PageInteractionHelper _pageInteractionHelper;
    private readonly FormCompletionHelper _formCompletionHelper;

    public TableRowHelper(PageInteractionHelper pageInteractionHelper, FormCompletionHelper formCompletionHelper)
    {
        _formCompletionHelper = formCompletionHelper;
        _pageInteractionHelper = pageInteractionHelper;
    }

    public IWebElement GetColumn(string rowIdentifier, By columnIdentifier, string tableSelector = "table", string tableRowSelector = "tbody tr", int tableposition = 0)
    {
        var table = _pageInteractionHelper.FindElements(By.CssSelector(tableSelector)).Where(x => x.Enabled && x.Displayed).ElementAtOrDefault(tableposition);
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
        var element = FindElementInTable(byLinkText, new List<string> { byKey }, tableSelector);

        var href = element?.GetAttribute("href");

        _formCompletionHelper.ClickElement(element);

        SetDebugInformation($"{byLinkText} with href - '{href}", byKey);
    }

    public IWebElement FindElementInTable(string byLinkText, List<string> byKeys, string tableSelector = "table")
    {
        var table = _pageInteractionHelper.FindElement(By.CssSelector(tableSelector));
        var tableRows = table.FindElements(By.CssSelector("tbody tr"));
        var links = _pageInteractionHelper.FindElements(By.PartialLinkText(byLinkText));
        int i = 0;
        foreach (IWebElement tableRow in tableRows)
        {
            if (byKeys.All(tableRow.Text.Contains)) return links[i];

            i++;
        }
        throw new System.Exception($"Test Exception: Could not find link with text '{byLinkText}' using key '{byKeys.ToString(",")}' and selector '{tableSelector}'");
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

                SetDebugInformation(byLinkText, byKey);

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
            int NoOfpages = RegexHelper.GetMaxNoOfPages(_pageInteractionHelper.GetText(noOfPages));

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

    private void SetDebugInformation(string x, string y ) => _formCompletionHelper.SetDebugInformation($"Clicked LinkText - '{x}' using Key - '{y}'");

}
