using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ManageRecruitPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "Manage Advert" : "Manage vacancy";

        protected static By EditAdvertActionSelector => By.CssSelector("a[href*='/edit-dates']");
        protected static By CloseAdvertActionSelector => By.CssSelector("a[href*='/close']");
        public CloneVacancyDatesPage CloneAdvert()
        {
            formCompletionHelper.ClickLinkByText("Clone advert");
            return new CloneVacancyDatesPage(context);
        }

        public EditVacancyDatesPage EditAdvert()
        {
            formCompletionHelper.ClickElement(EditAdvertActionSelector);
            return new EditVacancyDatesPage(context);
        }

        public CloseVacancyPage CloseAdvert()
        {
            formCompletionHelper.ClickElement(CloseAdvertActionSelector);
            return new CloseVacancyPage(context);
        }

    }
}
