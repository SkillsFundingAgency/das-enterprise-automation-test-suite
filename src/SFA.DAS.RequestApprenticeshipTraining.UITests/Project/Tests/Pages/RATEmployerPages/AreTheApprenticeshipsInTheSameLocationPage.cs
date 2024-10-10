using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class AreTheApprenticeshipsInTheSameLocationPage(ScenarioContext context) : BasePage(context)
    {
        protected override string PageTitle => "Are the apprenticeships in the same location?";

        #region Locators
        private static By ClickYesIfSame => By.CssSelector("label[for='SameLocation']");
        private static By ClickNoIfNot => By.CssSelector("label[for='SameLocation-no']");
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