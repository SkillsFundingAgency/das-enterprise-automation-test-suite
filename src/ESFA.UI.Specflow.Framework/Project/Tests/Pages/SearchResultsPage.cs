using System;
using ESFA.UI.Specflow.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;

namespace ESFA.UI.Specflow.Framework.Project.Tests.Pages
{
    public class SearchResultsPage : BasePage
    {
        private static String PAGE_TITLE = "";

        public SearchResultsPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        private By dfeLink(string searchText) => By.LinkText(searchText);

        internal DepartmentForEducationHomePage ClickDfeLink(string searchText)
        {
            FormCompletionHelper.ClickElement(dfeLink(searchText));
            return new DepartmentForEducationHomePage(webDriver);
        }
    }
}