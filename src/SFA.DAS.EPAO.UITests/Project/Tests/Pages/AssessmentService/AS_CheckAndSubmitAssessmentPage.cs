using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_CheckAndSubmitAssessmentPage : BasePage
    {
        protected override string PageTitle => "Check and submit the assessment details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

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
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_AssessmentRecordedPage ClickContinueInCheckAndSubmitAssessmentPage()
        {
            Continue();
            return new AS_AssessmentRecordedPage(_context);
        }

        public AS_WhatGradePage ClickGradeChangeLink()
        {
            _formCompletionHelper.ClickElement(GradeChangeLink);
            return new AS_WhatGradePage(_context);
        }

        public AS_WhichLearningOptionPage ClickOptionChangeLink()
        {
            _formCompletionHelper.ClickElement(OptionChangeLink);
            return new AS_WhichLearningOptionPage(_context);
        }

        public AS_AchievementDatePage ClickAchievementDateChangeLink()
        {
            _formCompletionHelper.ClickElement(AchievementDateChangeLink);
            return new AS_AchievementDatePage(_context);
        }

        public AS_RecipientNamePage ClickNameChangeLink()
        {
            _formCompletionHelper.ClickElement(NameChangeLink);
            return new AS_RecipientNamePage(_context);
        }

        public AS_RecipientNamePage ClickDepartmentChangeLink()
        {
            _formCompletionHelper.ClickElement(DepartmentChangeLink);
            return new AS_RecipientNamePage(_context);
        }

        public AS_EditEmployerAddress ClickOrganisationChangeLink()
        {
            _formCompletionHelper.ClickElement(OrganisationChangeLink);
            return new AS_EditEmployerAddress(_context);
        }

        public AS_EditEmployerAddress ClickCertificateAddressChangeLink()
        {
            _formCompletionHelper.ClickElement(AddressChangeLink);
            return new AS_EditEmployerAddress(_context);
        }
    }
}
