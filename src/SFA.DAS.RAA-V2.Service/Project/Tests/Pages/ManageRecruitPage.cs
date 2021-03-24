using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageRecruitPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "Manage advert" : "Manage vacancy";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Applicant => By.CssSelector(".responsive a");

        private By ActionLink => By.CssSelector("table tbody tr .govuk-link");

        public ManageRecruitPage(ScenarioContext context) : base(context) => _context = context;

        public RAAV2CSSBasePage CloneAdvert(bool permissionDenied = false)
        {
            string linkClone = isRaaV2Employer ? "Clone advert" : "Clone vacancy";
            formCompletionHelper.ClickLinkByText(linkClone);
            
            return permissionDenied
                ? new DoNotHavePermissionBasePage(_context)
                : new CloneVacancyDatesPage(_context) as RAAV2CSSBasePage;
        }

        public EditVacancyPage EditAdvert()
        {
            formCompletionHelper.ClickLinkByText("Edit advert");
            return new EditVacancyPage(_context);
        }

        public RAAV2CSSBasePage CloseAdvert(bool permissionDenied = false)
        {
            string linkClose = isRaaV2Employer ? "Close advert" : "Close vacancy";
            formCompletionHelper.ClickLinkByText(linkClose);

            return permissionDenied
                ? new DoNotHavePermissionBasePage(_context)
                : new CloseVacancyPage(_context) as RAAV2CSSBasePage;
        }

        public ViewVacancyPage NavigateToViewAdvertPage(string vacancyTitle = null)
        {
            string linkView = isRaaV2Employer ? "View advert" : "View vacancy";
            tabHelper.OpenInNewTab(() => formCompletionHelper.ClickLinkByText(linkView));

            return new ViewVacancyPage(_context, vacancyTitle);
        }

        public EditVacancyPage NavigateToEditAdvertPage()
        {
            string linkEdit = isRaaV2Employer ? "Edit advert" : "Edit vacancy";
            formCompletionHelper.ClickLinkByText(linkEdit);

            return new EditVacancyPage(_context);
        }

        public ManageApplicantPage NavigateToManageApplicant()
        {
            formCompletionHelper.Click(Applicant);
            return new ManageApplicantPage(_context);
        }
    }
}
