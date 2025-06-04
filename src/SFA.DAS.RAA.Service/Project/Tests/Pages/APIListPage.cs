using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ApiListPage(ScenarioContext context) : RaaBasePage(context)
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
        private readonly By DisplayAdvertApiText = By.XPath("//td[contains(text(), 'Display Advert API')]");
        #endregion

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

        public ApiListPage VerifyDisplayAdvertApiText()
        {
            pageInteractionHelper.CheckText(DisplayAdvertApiText, "Display Advert API");
            return new ApiListPage(context);
        }
    }
}