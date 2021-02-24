using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class TrainingProviderFoundPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => objectContext.GetUkprn();

        private By GovTag => By.CssSelector("#main-content .govuk-tag");

        public TrainingProviderFoundPage(ScenarioContext context) : base(context) => VerifyPage();

        public void VerifyStatus(string expectedStatus) => VerifyPage(GovTag, expectedStatus);
    }
}
