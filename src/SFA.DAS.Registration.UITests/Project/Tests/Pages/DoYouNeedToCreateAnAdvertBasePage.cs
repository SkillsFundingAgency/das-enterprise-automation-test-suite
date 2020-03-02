using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class DoYouNeedToCreateAnAdvertBasePage : BasePage
    {
        #region
        protected override string PageTitle => "Do you need to create an advert for this apprenticeship?";

        protected override By PageHeader => By.Id("heading-continue-setup-create-advert");
        #endregion

        public DoYouNeedToCreateAnAdvertBasePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
