using System;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;

namespace ESFA.UI.Specflow.Framework.Project.Tests.Pages
{
    class DepartmentForEducationHomePage : BasePage
    {
        private static String PAGE_TITLE = "";

        public DepartmentForEducationHomePage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            PageInteractionHelper p = new PageInteractionHelper(webDriver);
            return p.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        internal bool IsPageHeadingMacthing()
        {
            PageInteractionHelper p = new PageInteractionHelper(webDriver);
            return p.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }
    }
}