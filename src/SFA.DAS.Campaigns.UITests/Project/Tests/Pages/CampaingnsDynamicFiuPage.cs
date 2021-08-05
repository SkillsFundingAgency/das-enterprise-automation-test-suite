using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class CampaingnsDynamicFiuPage : CampaingnsHeaderBasePage
    {
        protected By FiuPageHeading => By.CssSelector(".fiu-page-heading__title");

        public CampaingnsDynamicFiuPage(ScenarioContext context, Action navigateAction, string pageTitle) : base(context) 
        {
            navigateAction();

            VerifyPage(FiuPageHeading, pageTitle);

            VerifyLinks();

            VerifyVideoLinks();
        }
        
    }
}
