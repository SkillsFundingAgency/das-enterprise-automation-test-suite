using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class DeleteVacancyQuestionPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => rAAV2DataHelper.VacancyTitle;

        private string SubTitle => isRaaV2Employer ? "Are you sure you want to delete this advert?" : "Are you sure you want to delete the vacancy?";

        private By SubHeader => By.CssSelector(".govuk-heading-l");

        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        public DeleteVacancyQuestionPage(ScenarioContext context) : base(context) => VerifyPage(SubHeader, SubTitle);

        public EmployerVacancySearchResultPage YesDeleteVacancy()
        {
            SelectRadioOptionByForAttribute("delete-yes");
            Continue();
            return new EmployerVacancySearchResultPage(context);
        }

        public PreviewYouAdvertOrVacancyPage NoDeleteVacancy()
        {
            SelectRadioOptionByForAttribute("delete-no");
            Continue();
            return new PreviewYouAdvertOrVacancyPage(context);
        }
    }
}
