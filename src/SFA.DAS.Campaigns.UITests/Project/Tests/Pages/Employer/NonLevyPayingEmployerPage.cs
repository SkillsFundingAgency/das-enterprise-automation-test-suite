using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class NonLevyPayingEmployerPage: EmployerBasePage
    {
        protected override string PageTitle => "Page not found";

        #region Page Object Element
        private readonly By _subHeading5 = By.XPath("//h2[contains (@class, 'heading-m' ) and contains(text(), 'Apprenticeships in Scotland, Northern Ireland and Wales')]");
        private readonly By _nonLevyText = By.XPath("//div[@class='page']/p");
        #endregion

        public NonLevyPayingEmployerPage(ScenarioContext context):base(context) 
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}