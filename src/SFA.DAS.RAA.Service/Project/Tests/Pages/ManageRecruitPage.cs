using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ManageRecruitPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "Manage Advert" : "Manage vacancy";

        public CloneVacancyDatesPage CloneAdvert()
        {
            formCompletionHelper.ClickLinkByText("Clone advert");
            return new CloneVacancyDatesPage(context);
        }

        public EditVacancyDatesPage EditAdvert()
        {
            formCompletionHelper.ClickLinkByText("Edit advert");
            return new EditVacancyDatesPage(context);
        }

        public CloseVacancyPage CloseAdvert()
        {
            formCompletionHelper.ClickLinkByText("Close advert");
            return new CloseVacancyPage(context);
        }

    }
}
