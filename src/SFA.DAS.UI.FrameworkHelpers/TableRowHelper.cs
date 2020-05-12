using OpenQA.Selenium;
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

        public void SelectRowFromTable(string byLinkText, string byKey, string tableSelector = "table")
        {
            var table = _pageInteractionHelper.FindElement(By.CssSelector(tableSelector));
            var tableRows = table.FindElements(By.CssSelector("tbody tr"));
            var links = _pageInteractionHelper.FindElements(By.PartialLinkText(byLinkText));
            int i = 0;
            foreach (IWebElement tableRow in tableRows)
            {
                if (tableRow.Text.Contains(byKey))
                {
                    _formCompletionHelper.ClickInterceptedElement(links[i]);
                    return;
                }
                i++;
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
