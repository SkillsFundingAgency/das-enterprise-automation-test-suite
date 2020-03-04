using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class RecruitmentLandingPage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Recruitment";
        protected override string Linktext => "Recruitment";

        #region Helpers And Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private readonly By StartNow = By.CssSelector("[data-automation='create-vacancy']");

        public RecruitmentLandingPage(ScenarioContext context, bool navigate = false) :base(context, navigate)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public RecruitmentHomePage ClickStartNow()
        {
            _formCompletionHelper.Click(StartNow);
            return new RecruitmentHomePage(_context);
        }
    }
}
