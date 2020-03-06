using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class RecruitmentLandingPage : BasePage
    {
        protected override string PageTitle => "Recruitment";

        #region Helpers And Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private readonly By StartNow = By.CssSelector("[data-automation='create-vacancy']");

        public RecruitmentLandingPage(ScenarioContext context) :base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public VacancyTitlePage ClickStartNow()
        {
            _formCompletionHelper.Click(StartNow);
            return new VacancyTitlePage(_context);
        }
    }
}
