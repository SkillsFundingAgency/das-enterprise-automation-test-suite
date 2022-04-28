using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ApiListPage : Raav2BasePage
    {
        protected override string PageTitle => "API list";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        private readonly By RecruitmentAPIViewKeyLink = By.CssSelector("#view-key-for-VacanciesManageOuterApi");
        private readonly By RecruitmentAPISandBoxViewKeyLink = By.CssSelector("#view-key-for-VacanciesManageOuterApi-Sandbox");
        private readonly By DisplayAPIViewKeyLink = By.CssSelector("#view-key-for-VacanciesOuterApi");
        private readonly By RecruitmentAPIGetLink = By.CssSelector("#get-key-for-VacanciesManageOuterApi");
        private readonly By RecruitmentAPISandBoxGetKeyLink = By.CssSelector("#get-key-for-VacanciesManageOuterApi-Sandbox");
        private readonly By DisplayAPIGetKeyLink = By.CssSelector("#get-key-for-VacanciesOuterApi");
        #endregion

        public ApiListPage(ScenarioContext context) : base(context) { }

        public KeyforApiPage ClickViewRecruitmentAPILink() => GoToKeyforAPIPage(RecruitmentAPIViewKeyLink, RecruitmentAPIGetLink);
       
        public KeyforApiPage ClickViewRecruitmentAPISandBoxLink() => GoToKeyforAPIPage(RecruitmentAPISandBoxViewKeyLink, RecruitmentAPISandBoxGetKeyLink);
       
        public KeyforApiPage ClickViewDisplayAPILink() => GoToKeyforAPIPage(DisplayAPIViewKeyLink, DisplayAPIGetKeyLink);

        private KeyforApiPage GoToKeyforAPIPage(By view, By get)
        {
            formCompletionHelper.Click(view);
            if (pageInteractionHelper.IsElementDisplayed(get))
            {
                formCompletionHelper.ClickElement(get);
            }
            return new KeyforApiPage(context);
        }
    }
}