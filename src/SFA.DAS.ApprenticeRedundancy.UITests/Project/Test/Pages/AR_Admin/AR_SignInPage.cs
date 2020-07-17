using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.AR_Admin
{
    public class AR_SignInPage : SignInBasePage
    {
        protected override string PageTitle => "ESFA Sign in";

        #region Helpers and Context
        private readonly ApprenticeRedundancyConfig _config;
        #endregion

        public AR_SignInPage(ScenarioContext context) : base(context) => _config = context.GetARConfig<ApprenticeRedundancyConfig>();

        public void SubmitValidLoginDetails() => SubmitValidLoginDetails(_config.AR_AdminUserName, _config.AR_AdminPassword);
    }
}

