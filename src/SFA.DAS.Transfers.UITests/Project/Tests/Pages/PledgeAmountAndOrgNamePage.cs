using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class PledgeAmountAndOrgNamePage : TransfersBasePage
    {
        private readonly ScenarioContext _context;
        public PledgeAmountAndOrgNamePage(ScenarioContext context) : base(context) => _context = context;
        private By pledgeAmountField = By.Id("Amount");


        protected override By PageHeader => By.ClassName("govuk-heading-xl");
        protected override string PageTitle => "Pledge amount and option to hide organisation name";


        public bool CheckPageTitle()
        {

            bool pageTitleOK = VerifyPage(PageHeader, PageTitle);
            return pageTitleOK;

        }

        public void ClickPledgeAmountLink()
        {
            formCompletionHelper.ClickElement(pledgeAmountField);

        }

        public void EnterPledgeAmount(int pledgeAmount)
        {
            formCompletionHelper.EnterText(pledgeAmountField, pledgeAmount);

        }

        public void EnterPledgeAmount(string pledgeAmount)
        {
            formCompletionHelper.EnterText(pledgeAmountField, pledgeAmount);

        }

        public void SelectAmount(int pledgeAmount)
        {
            formCompletionHelper.EnterText(pledgeAmountField, pledgeAmount);

        }

        public void SelectIsNamePublicRadioButton(string isNamePublic)
        {
            if (isNamePublic == "Yes")
            {
                formCompletionHelper.SelectRadioOptionByText("Yes");
            }
            else
            { 
                formCompletionHelper.SelectRadioOptionByText("No, I'd like our organisation to be anonymous"); 
            }

        }

        public void ClickContinue()
        {
            formCompletionHelper.ClickElement(ContinueButton);


        }

    }
}
