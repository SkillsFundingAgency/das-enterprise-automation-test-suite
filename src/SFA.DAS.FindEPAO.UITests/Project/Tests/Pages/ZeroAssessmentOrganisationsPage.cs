using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public class ZeroAssessmentOrganisationsPage : FindEPAOBasePage
    {
        protected override string PageTitle => "0 end-point assessment organisations";

        public ZeroAssessmentOrganisationsPage(ScenarioContext context) : base(context) { }

        #region Locators
        private static By ContactESFAButton => By.LinkText("Contact ESFA");
        #endregion

        public bool IsContactESFAButtonDisplayed() => pageInteractionHelper.IsElementDisplayed(ContactESFAButton);

    }
}