using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class CampaingnsDynamicFiuPage : CampaingnsHeaderBasePage
    {
        private static By FiuPageHeading => By.CssSelector(".govuk-heading-xl");

        public CampaingnsDynamicFiuPage(ScenarioContext context, string pageTitle) : base(context)
        {
            VerifyPage(FiuPageHeading, pageTitle);

            VerifyLinks();

            VerifyVideoLinks();
        }

    }
}
