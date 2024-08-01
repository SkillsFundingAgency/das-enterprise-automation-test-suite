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
    public class AreTheApprenticeshipsInTheSameLocationPage(ScenarioContext context) : BasePage(context)
    {
        protected override string PageTitle => "Are the apprenticeships in the same location?";

        #region Locators
        private static By ClickYesIfSame => By.XPath("(//input[@class='govuk-radios__input'])[1]");
        private static By ClickNoIfNot => By.XPath("(//input[@class='govuk-radios__input'])[2]");
        #endregion

        public AreTheApprenticeshipsInTheSameLocationPage ClickYesForSameLocation()
        {
            formCompletionHelper.Click(ClickYesIfSame);
            Continue();
            return new AreTheApprenticeshipsInTheSameLocationPage(context);
        }
        public AreTheApprenticeshipsInTheSameLocationPage ClickNoForADifferentLocation()
        {
            formCompletionHelper.Click(ClickNoIfNot);
            Continue();
            return new AreTheApprenticeshipsInTheSameLocationPage(context);
        }
    }
}