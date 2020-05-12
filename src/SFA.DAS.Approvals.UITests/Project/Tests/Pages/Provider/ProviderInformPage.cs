using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderInformPage : BasePage
    {
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By ChangeTheEmployerButton => By.Id("change-the-employer-button");

        public ProviderInformPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override string PageTitle => "What you'll need";

        public ChangeOfEmployerSelectEmployerPage SelectChangeTheEmployer()
        {
            _formCompletionHelper.Click(ChangeTheEmployerButton);
            return new ChangeOfEmployerSelectEmployerPage(_context);
        }
    }
}
