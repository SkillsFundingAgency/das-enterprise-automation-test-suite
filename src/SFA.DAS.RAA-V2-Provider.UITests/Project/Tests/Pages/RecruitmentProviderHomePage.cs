using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class RecruitmentProviderHomePage : ProviderHomePage
    {
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public RecruitmentProviderHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public RecruitmentHomePage RecruitApprentices()
        {
            _formCompletionHelper.ClickLinkByText("Recruit apprentices");
            return new RecruitmentHomePage(_context);
        }
    }
}
