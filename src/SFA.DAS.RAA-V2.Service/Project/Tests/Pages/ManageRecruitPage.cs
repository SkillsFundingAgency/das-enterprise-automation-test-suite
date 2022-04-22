using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageRecruitPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "Manage advert" : "Manage vacancy";

        private By Applicant => By.CssSelector(".das-table--responsive a");

        public ManageRecruitPage(ScenarioContext context) : base(context) { }

        public CloneVacancyDatesPage CloneAdvert()
        {
            formCompletionHelper.ClickLinkByText("Clone advert");
            return new CloneVacancyDatesPage(context);
        }

        public EditVacancyPage EditAdvert()
        {
            formCompletionHelper.ClickLinkByText("Edit advert");
            return new EditVacancyPage(context);
        }

        public CloseVacancyPage CloseAdvert()
        {
            formCompletionHelper.ClickLinkByText("Close advert");
            return new CloseVacancyPage(context);
        }

        public ViewVacancyPage NavigateToViewAdvertPage()
        {
            string linkTest = isRaaV2Employer ? "View advert" : "View vacancy";
            tabHelper.OpenInNewTab(() => formCompletionHelper.ClickLinkByText(linkTest));

            return new ViewVacancyPage(context);
        }

        public ManageApplicantPage NavigateToManageApplicant()
        {
            formCompletionHelper.Click(Applicant);
            return new ManageApplicantPage(context);
        }
    }
}
