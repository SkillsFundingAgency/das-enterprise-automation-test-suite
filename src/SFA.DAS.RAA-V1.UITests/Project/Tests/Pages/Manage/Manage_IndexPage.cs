using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_IndexPage : BasePage
    {
        protected override string PageTitle => "Recruitment";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private readonly By AgencyButton = By.CssSelector(".button");

        public Manage_IndexPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public IdamsPage ClickAgencyButton()
        {
            _formCompletionHelper.Click(AgencyButton);
            return new IdamsPage(_context);
        }

    }
}
