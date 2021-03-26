using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public class ZeroAssessmentOrganisationsPage : FindEPAOBasePage
    {
        protected override string PageTitle => "0 end-point assessment organisations";
        private readonly ScenarioContext _context;
        public ZeroAssessmentOrganisationsPage(ScenarioContext context) : base(context) => _context = context;

        #region Locators
        private By ContactESFAButton => By.LinkText("Contact ESFA");
        #endregion

        public bool IsContactESFAButtonDisplayed() => pageInteractionHelper.IsElementDisplayed(ContactESFAButton);

    }
}