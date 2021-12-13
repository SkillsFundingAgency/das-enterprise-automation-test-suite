using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.AllowList
{
    public class ConfirmationPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Removed from allow list";


        public ConfirmationPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}