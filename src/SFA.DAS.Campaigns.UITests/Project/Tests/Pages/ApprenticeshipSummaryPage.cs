using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class ApprenticeshipSummaryPage : BasePage
    {
        protected override string PageTitle => objectContext.GetVacancyTitle();

        protected override By PageHeader => By.CssSelector("#vacancy-title");

        #region Helpers and Context
        private readonly ObjectContext objectContext;
        #endregion

        public ApprenticeshipSummaryPage(ScenarioContext context) : base(context) 
        {
            objectContext = context.Get<ObjectContext>();
            VerifyPage(); 
        }
    }
}
