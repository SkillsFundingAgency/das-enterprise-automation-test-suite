using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_CheckAndSubmitAssessmentPage : EPAO_BasePage
    {
        protected override string PageTitle => "Check and submit the assessment details";
        private readonly ScenarioContext _context;

        #region Locators
        private By GradeChangeLink => By.XPath("//a[@href='/certificate/grade?redirecttocheck=true']");
        private By OptionChangeLink => By.XPath("//a[@href='/certificate/option?redirecttocheck=true']");
        private By AchievementDateChangeLink => By.XPath("//a[@href='/certificate/date?redirecttocheck=true']");
        private By NameChangeLink => By.XPath("//dt[contains(text(), 'Name')]/../dd/a");
        private By DepartmentChangeLink => By.XPath("//dt[contains(text(), 'Department')]/../dd/a");
        private By OrganisationChangeLink => By.XPath("//dt[contains(text(), 'Organisation')]/../dd/a");
        private By AddressChangeLink => By.XPath("//dt[contains(text(), 'Address')]/../dd/a");
        #endregion

        public AS_CheckAndSubmitAssessmentPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_AssessmentRecordedPage ClickContinueInCheckAndSubmitAssessmentPage()
        {
            Continue();
            return new AS_AssessmentRecordedPage(_context);
        }

        public AS_WhatGradePage ClickGradeChangeLink()
        {
            formCompletionHelper.ClickElement(GradeChangeLink);
            return new AS_WhatGradePage(_context);
        }

        public AS_WhichLearningOptionPage ClickOptionChangeLink()
        {
            formCompletionHelper.ClickElement(OptionChangeLink);
            return new AS_WhichLearningOptionPage(_context);
        }

        public AS_AchievementDatePage ClickAchievementDateChangeLink()
        {
            formCompletionHelper.ClickElement(AchievementDateChangeLink);
            return new AS_AchievementDatePage(_context);
        }

        public AS_RecipientNamePage ClickNameChangeLink()
        {
            formCompletionHelper.ClickElement(NameChangeLink);
            return new AS_RecipientNamePage(_context);
        }

        public AS_RecipientNamePage ClickDepartmentChangeLink()
        {
            formCompletionHelper.ClickElement(DepartmentChangeLink);
            return new AS_RecipientNamePage(_context);
        }

        public AS_EditEmployerAddress ClickOrganisationChangeLink()
        {
            formCompletionHelper.ClickElement(OrganisationChangeLink);
            return new AS_EditEmployerAddress(_context);
        }

        public AS_EditEmployerAddress ClickCertificateAddressChangeLink()
        {
            formCompletionHelper.ClickElement(AddressChangeLink);
            return new AS_EditEmployerAddress(_context);
        }
    }
}
