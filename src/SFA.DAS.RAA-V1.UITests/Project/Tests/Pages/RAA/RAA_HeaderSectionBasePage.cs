using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAA_HeaderSectionBasePage : BasePage
    {
        private By SignOut => By.Id("signout-link");

        private By Home => By.CssSelector("#applicationsLink");

        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly RAADataHelper dataHelper;
        #endregion

        public RAA_HeaderSectionBasePage(ScenarioContext context, bool navigate) : this(context)
        {
            formCompletionHelper = context.Get<FormCompletionHelper>();
            if (navigate) { formCompletionHelper.Click(Home); }
        }

        public RAA_HeaderSectionBasePage(ScenarioContext context) : base(context)
        {
            dataHelper = context.Get<RAADataHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public void ExitFromWebsite()
        {
            formCompletionHelper.Click(SignOut);
        }
    }
}
