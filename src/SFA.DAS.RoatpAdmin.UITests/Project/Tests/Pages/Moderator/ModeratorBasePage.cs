using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public abstract class ModeratorBasePage : RoatpBasePage
    {
        private readonly ScenarioContext _context;

        protected By StatusTextLocator(string linkText) =>
            By.XPath($"//span[contains(text(), '{linkText}')]/following-sibling::strong | //a[contains(text(),'{linkText}')]/../following-sibling::strong");

        protected ModeratorBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ModerationApplicationAssessmentOverviewPage SelectPassAndContinue()
        {
            SelectPassAndContinueToSubSection();
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }

        public void SelectPassAndContinueToSubSection()
        {
            SelectRadioOptionByText("Pass");
            Continue();
        }

        public ModerationApplicationsPage VerifyApplicationStatus(By statusSelector, string expectedStatus, Action action)
        {
            var linkText = objectContext.GetProviderName();

            action.Invoke();

            VerifyElement(() => tableRowHelper.GetColumn(linkText, statusSelector), expectedStatus, action);
            
            return new ModerationApplicationsPage(_context);
        }

        public ModerationApplicationAssessmentOverviewPage VerifyStatus(string linkText, string expectedStatus)
        {
            VerifyStatusBesideGenericQuestion(linkText, expectedStatus);

            return new ModerationApplicationAssessmentOverviewPage(_context);
        }

        public void VerifyStatusBesideGenericQuestion(string linkText, string expectedStatus) => 
            VerifyElement(() => pageInteractionHelper.FindElement(StatusTextLocator(linkText)), expectedStatus, null);
    }
}
