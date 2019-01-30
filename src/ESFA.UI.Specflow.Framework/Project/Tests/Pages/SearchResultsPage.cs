using System;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
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
            PageInteractionHelper p = new PageInteractionHelper(webDriver);
            return p.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        private By dfeLink = By.LinkText("Department for Education");

        internal DepartmentForEducationHomePage ClickDfeLink()
        {
            FormCompletionHelper f = new FormCompletionHelper(webDriver);
            f.ClickElement(dfeLink);
            return new DepartmentForEducationHomePage(webDriver);
        }
    }
}