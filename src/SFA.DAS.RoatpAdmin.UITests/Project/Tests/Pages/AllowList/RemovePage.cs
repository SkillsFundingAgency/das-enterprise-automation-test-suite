using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.AllowList
{
    public class RemovePage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Are you sure you want to remove this UKPRN?";

        public RemovePage(ScenarioContext context) : base(context) => VerifyPage();

        public ConfirmationPage SelectYesRemoveUkprn()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new ConfirmationPage(context);
        }
    }
}