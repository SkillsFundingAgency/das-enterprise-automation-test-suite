using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;


namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class ApplicationOutcomePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Application ";
        protected By InternalComments => By.CssSelector(".govuk-body.das-multiline-text, p:nth-child(4)");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApplicationOutcomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public void VerifyExternalComments(String internalComments)
        {
            pageInteractionHelper.VerifyText(InternalComments, internalComments);
        }

        public ApplicationOutcomePage VerifyApplicationOutcomePage(string expectedPage, string externalComments)
        {
            
            pageInteractionHelper.VerifyText(PageHeader, expectedPage);
            if ((string.IsNullOrEmpty(externalComments)  == false))
            VerifyExternalComments(externalComments);
            return this;
        }
    }
}
