using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class APIListPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "API list";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        private readonly By RecruitmentAPIViewKeyLink = By.Id("view-key-for-VacanciesManageOuterApi");
        private readonly By RecruitmentAPISandBoxViewKeyLink = By.Id("view-key-for-VacanciesManageOuterApi-Sandbox");
        private readonly By DisplayAPIViewKeyLink = By.Id("view-key-for-VacanciesOuterApi");
        private readonly By RecruitmentAPIGetLink = By.Id("get-key-for-VacanciesManageOuterApi");
        private readonly By RecruitmentAPISandBoxGetKeyLink = By.Id("get-key-for-VacanciesManageOuterApi-Sandbox");
        private readonly By DisplayAPIGetKeyLink = By.Id("get-key-for-VacanciesOuterApi");


        #endregion

        public APIListPage(ScenarioContext context) : base(context) { }

        public KeyforAPIPage ClickViewRecruitmentAPILink()
        {
            formCompletionHelper.Click(RecruitmentAPIViewKeyLink);
            if (pageInteractionHelper.IsElementDisplayed(RecruitmentAPIGetLink))
            {
                formCompletionHelper.ClickElement(RecruitmentAPIGetLink);
            }
            return new KeyforAPIPage(context);
        }
        public KeyforAPIPage ClickViewRecruitmentAPISandBoxLink()
        {
            formCompletionHelper.Click(RecruitmentAPISandBoxViewKeyLink);
            if (pageInteractionHelper.IsElementDisplayed(RecruitmentAPIGetLink))
            {
                formCompletionHelper.ClickElement(RecruitmentAPIGetLink);
            }
            return new KeyforAPIPage(context);
        }
        public KeyforAPIPage ClickViewDisplayAPILink()
        {
            formCompletionHelper.Click(DisplayAPIViewKeyLink);
            if (pageInteractionHelper.IsElementDisplayed(RecruitmentAPIGetLink))
            {
                formCompletionHelper.ClickElement(RecruitmentAPIGetLink);
            }
            return new KeyforAPIPage(context);
        }
    }
}