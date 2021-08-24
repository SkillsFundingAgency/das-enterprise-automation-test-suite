using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class CreateATransfersPledgePage : TransfersBasePage
    {
        private readonly ScenarioContext _context;
        public CreateATransfersPledgePage(ScenarioContext context) : base(context) => _context = context;
        private By pledgeAmountLink = By.LinkText("Amount you want to pledge");
        private By submitMyPledgeButton = By.Id("pledge-create-submit");


        protected override By PageHeader => By.ClassName("govuk-heading-xl");
        protected override string PageTitle => "Create a transfer pledge";
 

        public bool CheckPageTitle()
        {

            bool pageTitleOK = VerifyPage(PageHeader, PageTitle);
            return pageTitleOK;

        }

        public void ClickPledgeAmountLink()
        {
            formCompletionHelper.ClickElement(pledgeAmountLink);

        }

        public void CheckSubmitButtonActivated()
        {
            pageInteractionHelper.WaitForElementToBeDisplayed(submitMyPledgeButton);
        }

        public void ClickSubmitMyPledge()
        {
            formCompletionHelper.ClickElement(submitMyPledgeButton);


        }

    }
}
