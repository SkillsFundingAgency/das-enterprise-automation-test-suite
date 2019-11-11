using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ClosedVacancyPreviewPage : RAA_VacancyPreviewPage
    {

        private By VacancyInfoText => By.CssSelector(".info-summary > p");

        public RAA_ClosedVacancyPreviewPage(ScenarioContext context) : base(context) { }

        public string GetVacancyInfo()
        {
            return pageInteractionHelper.GetText(VacancyInfoText);
        }
    }
}
