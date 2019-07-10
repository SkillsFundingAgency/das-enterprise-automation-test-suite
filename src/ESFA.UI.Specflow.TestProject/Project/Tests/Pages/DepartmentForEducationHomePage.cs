using System;
using ESFA.UI.Specflow.Framework.Helpers;
using ESFA.UI.Specflow.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.Pages
{
    class DepartmentForEducationHomePage : BasePage
    {
        private static String PAGE_TITLE = "";

        private PageInteractionHelper pageInteractionHelper;

        public DepartmentForEducationHomePage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper = context.Get<PageInteractionHelper>();
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