using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAA_HeaderSectionBasePage : BasePage
    {
        private By SignOut => By.Id("signout-link");

        private By Home => By.CssSelector("#applicationsLink");

        private By Admin => By.CssSelector("#adminLink");

        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly RAAV1DataHelper dataHelper;
        protected readonly VacancyTitleDatahelper vacancyTitledataHelper;
        #endregion

        public RAA_HeaderSectionBasePage(ScenarioContext context, bool navigate = false) : base(context)
        {
            dataHelper = context.Get<RAAV1DataHelper>();
            vacancyTitledataHelper = context.Get<VacancyTitleDatahelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            if (navigate) { NavigateToHome(); }
            VerifyPage();
        }

        protected void NavigateToHome() => formCompletionHelper.Click(Home);

        protected void NavigateToAdmin() => formCompletionHelper.Click(Admin);


        public void ExitFromWebsite()
        {
            formCompletionHelper.Click(SignOut);
        }
    }
}
