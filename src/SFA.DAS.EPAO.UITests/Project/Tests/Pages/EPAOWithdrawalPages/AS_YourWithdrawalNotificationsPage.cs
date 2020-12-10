using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_YourWithdrawalNotificationsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Your withdrawal notifications";
        private readonly ScenarioContext _context;
        public AS_YourWithdrawalNotificationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

    }
}
