using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class DeleteVacancyQuestionPage : RaaBasePage
    {
        protected override string PageTitle => rAADataHelper.VacancyTitle;

        protected override string AccessibilityPageTitle => "Delete vacancy page";

        private string SubTitle => isRaaEmployer ? "Are you sure you want to delete this advert?" : "Are you sure you want to delete the vacancy?";

        private static By SubHeader => By.CssSelector(".govuk-heading-l");

        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        public DeleteVacancyQuestionPage(ScenarioContext context) : base(context) => VerifyPage(SubHeader, SubTitle);

        public EmployerVacancySearchResultPage YesDeleteAdvert()
        {
            SelectRadioOptionByForAttribute("delete-yes");
            Continue();
            return new EmployerVacancySearchResultPage(context);
        }

        public ProviderVacancySearchResultPage YesDeleteVacancy()
        {
            SelectRadioOptionByForAttribute("delete-yes");
            Continue();
            return new ProviderVacancySearchResultPage(context);
        }

        public CreateAnApprenticeshipAdvertOrVacancyPage NoDeleteVacancy()
        {
            SelectRadioOptionByForAttribute("delete-no");
            Continue();
            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }
    }
}
