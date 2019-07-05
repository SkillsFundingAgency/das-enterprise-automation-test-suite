using System;
using ESFA.UI.Specflow.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.Pages
{
    class DepartmentForEducationHomePage : BasePage
    {
        private static String PAGE_TITLE = "";

        private PageInteractionHelper pageInteractionHelper;

        public DepartmentForEducationHomePage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            pageInteractionHelper = scenarioContext.Get<PageInteractionHelper>();
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        internal bool IsPageHeadingMacthing()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }
    }
}