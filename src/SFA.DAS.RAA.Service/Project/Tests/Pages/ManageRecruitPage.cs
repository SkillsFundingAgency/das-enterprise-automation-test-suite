using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ManageRecruitPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "Manage Advert" : "Manage vacancy";

        protected static By EditAdvertActionSelector => By.XPath("//a[@class='govuk-link' and contains(@href, 'edit-dates') and text()='Change']");
        protected static By CloseAdvertActionSelector => By.XPath("//a[@class='govuk-link' and contains(@href, 'close') and text()='Change']");
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
