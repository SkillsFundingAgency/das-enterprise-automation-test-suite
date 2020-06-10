using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AuditDetailsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Audit details";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ReasonToDeleteCertificate => By.Id("ReasonForChange");
        private By IncidentNumberToDeleteCertificate => By.Id("IncidentNumber");
        public AuditDetailsPage (ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public CheckYourAnswersBeforeDeletingThisCertificatePage EnterAuditDetails()
        {
            formCompletionHelper.EnterText(ReasonToDeleteCertificate, "EAPO Entered incorrect details");
            formCompletionHelper.EnterText(IncidentNumberToDeleteCertificate, "INC-014589527");
            Continue();
            return new CheckYourAnswersBeforeDeletingThisCertificatePage(_context);
        }
    }
}