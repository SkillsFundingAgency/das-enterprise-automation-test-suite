using OpenQA.Selenium;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class TableRowHelper 
    {
        private readonly IWebDriver _webDriver;
        private readonly FormCompletionHelper _formCompletionHelper;

        public TableRowHelper(IWebDriver webDriver, FormCompletionHelper formCompletionHelper)
        {
            _webDriver = webDriver;
            _formCompletionHelper = formCompletionHelper;
        }

        public void SelectRowFromTable(string byLinkText, string byKey)
        {
            var table = _webDriver.FindElement(By.TagName("table"));
            var tableRows = table.FindElements(By.CssSelector("tbody tr"));
            var links = _webDriver.FindElements(By.PartialLinkText(byLinkText));
            int i = 0;
            foreach (IWebElement tableRow in tableRows)
            {
                if (tableRow.Text.Contains(byKey))
                {
                    _formCompletionHelper.ClickElement(links[i]);
                    return;
                }
                i++;
            }
            throw new System.Exception($"Test Exception: Could not find link with text {byLinkText} using key {byKey}");
        }
    }
}
