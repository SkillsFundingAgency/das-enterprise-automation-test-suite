using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class AreApprenticeShipRightForMePage: ApprenticeBasePage
    {
        protected override string PageTitle => "Page not found";

        public AreApprenticeShipRightForMePage(ScenarioContext context):base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}