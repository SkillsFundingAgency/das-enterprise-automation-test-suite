using SFA.DAS.Registration.UITests.Project;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ClosePledgePage : TransferMatchingBasePage
    {
        protected override string PageTitle => $"Close pledge {GetPledgeId()}";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        public ClosePledgePage(ScenarioContext context) : base(context) { }

        private By NoSelector => By.CssSelector("#close-pledge-no");
        private By YesSelector => By.CssSelector("#close-pledge-yes");


        public TransferPledgePage DontClose()
        {
            formCompletionHelper.SelectRadioOptionByLocator(NoSelector);
            Continue();
            return new TransferPledgePage(context);
        }

        public MyTransferPledgesPage ConfirmClose()
        {
            formCompletionHelper.SelectRadioOptionByLocator(YesSelector);
            Continue();
            return new MyTransferPledgesPage(context);
        }
    }
}