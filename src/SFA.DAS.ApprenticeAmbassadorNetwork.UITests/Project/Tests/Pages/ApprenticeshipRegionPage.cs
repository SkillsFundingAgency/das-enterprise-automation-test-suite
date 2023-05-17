using System;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class RegionsPage : CurrentJobTitlePage
    {
        protected override string PageTitle => pageTitle;

        private readonly string pageTitle;

        public TermsAndConditionsPage(ScenarioContext context) : base(context) => VerifyPage();

        private static By YesRadio => By.id("SelectedRegionId");

        public RegionsPage ClickConfirmAndContinueButton()
        {
            clickContinueButton By.Id("continue-button");
            return new RegionsPage(context);
        }

        
    }
}

        

