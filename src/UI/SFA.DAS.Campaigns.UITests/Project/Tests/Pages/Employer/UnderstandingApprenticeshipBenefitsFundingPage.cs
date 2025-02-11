using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class UnderstandingApprenticeshipBenefitsFundingPage(ScenarioContext context) : EmployerBasePage(context)
    {
        protected override string PageTitle => "Understanding apprenticeship benefits and funding";

        #region Page Object Element

        private readonly By Under3Million = By.CssSelector("label[for='PayBillGreaterThanThreeMillion']");
        private readonly By Over3Million = By.CssSelector("label[for='pay-bill-over']");
        private readonly By TrainingCourse = By.CssSelector("#StandardUid");
        private readonly By NumberOfRolesAvailable = By.CssSelector("#NumberOfRoles");
        private readonly By CalculateFunding = By.CssSelector("button[type='submit']");
        

        #endregion

        public UBAFEstimatedFundingBasePage SelectUnder3Million()
        {
            formCompletionHelper.SelectRadioOptionByLocator(Under3Million);
            formCompletionHelper.SendKeys(TrainingCourse, campaignsDataHelper.Course);
            formCompletionHelper.SendKeys(NumberOfRolesAvailable,campaignsDataHelper.Positions);
            formCompletionHelper.ClickElement(CalculateFunding);
            return new UBAFEstimatedFundingBasePage(context);
        }

        public UBAFEstimatedFundingBasePage SelectOver3Million()
        {
            formCompletionHelper.SelectRadioOptionByLocator(Over3Million);
            formCompletionHelper.SendKeys(TrainingCourse, campaignsDataHelper.Course);
            formCompletionHelper.SendKeys(NumberOfRolesAvailable, campaignsDataHelper.Positions);
            formCompletionHelper.ClickElement(CalculateFunding);
            return new UBAFEstimatedFundingBasePage(context);
        }
    }
}
