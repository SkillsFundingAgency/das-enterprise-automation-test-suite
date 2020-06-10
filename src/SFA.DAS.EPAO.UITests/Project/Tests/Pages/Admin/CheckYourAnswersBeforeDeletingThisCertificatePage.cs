using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class CheckYourAnswersBeforeDeletingThisCertificatePage :EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Check your answers before deleting this certificate";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By DeleteCertificate => By.CssSelector(".govuk-button");

        public CheckYourAnswersBeforeDeletingThisCertificatePage (ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public YouHaveSuccessfullyDeletedPage ClickDeleteCertificateButton()
        {
            formCompletionHelper.ClickElement(DeleteCertificate);
            return new YouHaveSuccessfullyDeletedPage(_context);
        }
    }
}