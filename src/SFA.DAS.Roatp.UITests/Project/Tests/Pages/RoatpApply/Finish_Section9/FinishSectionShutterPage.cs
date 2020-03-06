using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9
{
    public class FinishSectionShutterPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Before you submit your application";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FinishSectionShutterPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApplicationOverviewPage ReturnToApplicationOverview()
        {
            formCompletionHelper.ClickLinkByText("Application overview");
            return new ApplicationOverviewPage(_context);
        }
    }
}
   