using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class RegionWise_MultiLocation_WhereIsTheApprenticeshipLocationPage(ScenarioContext context) : BasePage(context)

    {
        protected override string PageTitle => "Where is the apprenticeship location?";

        #region Locators
        private static By ClickEastMidlands => By.LinkText("Derby");
        #endregion

        public RegionWise_MultiLocation_WhereIsTheApprenticeshipLocationPage ClickRegionWiseCheckbox()
        {
            formCompletionHelper.Click(ClickEastMidlands);
            Continue();
            return new RegionWise_MultiLocation_WhereIsTheApprenticeshipLocationPage(context);
        }
    }
}
