using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.FinancialHealthAssessmentSection
{
    public class AP_FHA_FinancialHealthPage : EPAOApply_BasePage
    {
        protected override string PageTitle => "Financial health";
        private readonly ScenarioContext _context;

        public AP_FHA_FinancialHealthPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_FHABasePage UploadFileAndContinueInFinancialHealthPage()
        {
            UploadFile();
            return new AP_FHABasePage(_context);
        }
    }
}
