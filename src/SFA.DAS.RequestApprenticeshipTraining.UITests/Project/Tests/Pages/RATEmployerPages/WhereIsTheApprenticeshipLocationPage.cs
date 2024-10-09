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
    public class WhereIsTheApprenticeshipLocationPage(ScenarioContext context) : BasePage(context)
    {
        protected override string PageTitle => "Where is the apprenticeship location?";

        #region Locators
        private static By EnterLocation => By.CssSelector(".autocomplete__input autocomplete__input--default");
        #endregion

        public WhereIsTheApprenticeshipLocationPage EnterCityTownPostcode()
        {
            formCompletionHelper.EnterText(EnterLocation, "CV1 2WT");
            Continue();
            return new WhereIsTheApprenticeshipLocationPage(context);
        }
    }
}
