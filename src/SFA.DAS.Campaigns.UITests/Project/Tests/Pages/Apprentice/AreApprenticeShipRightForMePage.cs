using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class AreApprenticeShipRightForMePage: ApprenticeBasePage
    {
        protected override string PageTitle => "Are apprenticeships right for me?";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AreApprenticeShipRightForMePage(ScenarioContext context):base(context)
        {
            _context = context;
            //content check
        }
    }
}