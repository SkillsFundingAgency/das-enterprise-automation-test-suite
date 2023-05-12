using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using System.Linq;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using Selenium.Axe;
using SFA.DAS.TestDataExport;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class AnalyzePageHelper
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        public AnalyzePageHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        internal void AnalyzePage(string actualPageTitle)
        {
            if (!ShouldAnalyzePage()) return;

            string pageTitle = string.IsNullOrEmpty(actualPageTitle) ? "NoPageTitle" : actualPageTitle;

            string counter = _context.Get<ScreenShotTitleGenerator>().GetTitle();

            string fileName = $"{RegexHelper.TrimAnySpace($"{counter}_{pageTitle}")}.html";

            var directory = _objectContext.GetDirectory();

            (string _, string escapedfileName) = new WindowsFileHelper().GetFileDetails(directory, fileName);

            AxeResult axeResult = null;

            TestAttachmentHelper.AddTestAttachment(directory, escapedfileName, (x) =>
            {
                IWebDriver webDriver = _context.GetWebDriver();

                axeResult = new AxeBuilder(webDriver).Analyze();

                webDriver.CreateAxeHtmlReport(axeResult, x, ReportTypes.Violations);
            });

            if (axeResult.Violations.Any(x => x.Impact.ContainsCompareCaseInsensitive("CRITICAL")))
            {
                SetAccessibilityInformation($"{axeResult.Violations.Length} CRITICAL violation's is/are found in {counter} - '{pageTitle}' page - url: {axeResult.Url}");
            }
        }

        private bool ShouldAnalyzePage()
        {
            var analyzedPages = _objectContext.GetAccessibilityInformations();

            var url = _context.Get<PageInteractionHelper>().GetUrl();

            if (analyzedPages.Any(x=> x.Contains(url))) return false;

            var urlsplit = url.Split("?");

            if (urlsplit.Any() && analyzedPages.Any(x => x.Contains(urlsplit[0]))) return false;
            
            return true;
        }

        private void SetAccessibilityInformation(string x) => _objectContext.SetAccessibilityInformation(x);
    }
}