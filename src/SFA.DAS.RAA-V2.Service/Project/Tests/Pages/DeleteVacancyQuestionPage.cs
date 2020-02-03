using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class DeleteVacancyQuestionPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => dataHelper.VacancyTitle;

        private string SubTitle => "Are you sure you want to delete the vacancy?";

        private By SubHeader => By.CssSelector(".govuk-heading-l");

        private By Continue => By.CssSelector("input[type='submit'][value='Continue']");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public DeleteVacancyQuestionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage(SubHeader, SubTitle);
        }

        public VacanciesPage YesDeleteVacancy()
        {
            SelectRadioOptionByForAttribute("delete-yes");
            formCompletionHelper.Click(Continue);
            return new VacanciesPage(_context);
        }

        public VacancyPreviewPart2Page NoDeleteVacancy()
        {
            SelectRadioOptionByForAttribute("delete-no");
            formCompletionHelper.Click(Continue);
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
