using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public abstract class AssessorBasePage : RoatpBasePage
    {
        private readonly ScenarioContext _context;
        public By StatusTextLocator(string linkText) =>
            By.XPath($"//span[contains(text(), '{linkText}')]/following-sibling::strong | //a[contains(text(),'{linkText}')]/../following-sibling::strong");

        protected AssessorBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationAssessmentOverviewPage SelectPassAndContinue()
        {
            SelectPassAndContinueToSubSection();
            return new ApplicationAssessmentOverviewPage(_context);
        }

        public void SelectPassAndContinueToSubSection()
        {
            SelectRadioOptionByText("Pass");
            Continue();
        }

        public ApplicationAssessmentOverviewPage VerifyStatus(string linkText, string expectedStatus)
        {
            Assert.AreEqual(expectedStatus, pageInteractionHelper.GetText(StatusTextLocator(linkText)), $"Status of '{linkText}' is Incorrect");
            return new ApplicationAssessmentOverviewPage(_context);
        }

        public void VerifyStatusBesideGenericQuestion(string linkText, string expectedStatus) =>
           Assert.AreEqual(expectedStatus, pageInteractionHelper.GetText(StatusTextLocator(linkText)), $"Status of '{linkText}' is Incorrect");
    }
}
