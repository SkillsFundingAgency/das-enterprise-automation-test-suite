using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class DeleteVacancyQuestionPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => _pageTitle ?? rAAV2DataHelper.VacancyTitle;
        private string _pageTitle;

        private string SubTitle => isRaaV2Employer ? "Are you sure you want to delete this advert?" : "Are you sure you want to delete the vacancy?";

        private By SubHeader => By.CssSelector(".govuk-heading-l");

        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public DeleteVacancyQuestionPage(ScenarioContext context, string pageTitle = null, bool verifypage = true) : base(context, false)
        {
            _context = context;
            _pageTitle = pageTitle;
            if (verifypage)
            {
                VerifyPage();
                VerifyPage(SubHeader, SubTitle);
            }
        }

        public YourAdvertsPage YesDeleteVacancy()
        {
            SelectRadioOptionByForAttribute("delete-yes");
            Continue();
            return new YourAdvertsPage(_context);
        }

        public VacancyPreviewPart2Page NoDeleteVacancy()
        {
            SelectRadioOptionByForAttribute("delete-no");
            Continue();
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
