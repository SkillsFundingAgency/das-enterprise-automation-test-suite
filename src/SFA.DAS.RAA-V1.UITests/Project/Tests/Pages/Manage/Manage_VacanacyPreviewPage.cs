using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_VacanacyPreviewPage : Manage_HeaderSectionBasePage
    {
        protected override string PageTitle => "Vacancy preview";

        private By Refer => By.CssSelector("#btnReject");
        

        public Manage_VacanacyPreviewPage(ScenarioContext context) : base(context) { }

        public void ReferVacancy()
        {
            formCompletionHelper.Click(Refer);
            SignOut();
        }
    }
}
