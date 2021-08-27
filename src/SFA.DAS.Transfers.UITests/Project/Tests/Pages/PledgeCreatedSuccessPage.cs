using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Transfers.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class PledgeCreatedSuccessPage //: TransfersBasePage
    {

        private readonly ScenarioContext _context;
        //private IWebDriver _webDriver;

        private By pledgeCreatedConfirmationPanel = By.ClassName("govuk-panel__title");
        private string confirmationTitleSubstring = "Your pledge has been created as pledge number";
        private string pledgeConfirmationFullMessage;
        public static string pledgeID;
       
        public PledgeCreatedSuccessPage(ScenarioContext context) => _context = context;// : base(context) => _context = context;


     

        //public PledgeCreatedSuccessPage(IWebDriver webDriver) 

        //{
        //    _webDriver = webDriver;
        //}
    //protected override string PageTitle => "Your pledge has been created as pledge number*";
    public bool CheckPagePanelTitle()
            {
            
            LevyTransfersStepsHelper levyTransfersStepsHelper = new LevyTransfersStepsHelper(_context);
            bool pageTitleOK = levyTransfersStepsHelper.DoesConfirmationBoxContainSubstring(pledgeCreatedConfirmationPanel, confirmationTitleSubstring);

            return pageTitleOK;

            } 

    public string GetNewPledgeID()
        {

            IWebDriver _webDriver = _context.GetWebDriver();
            
            pledgeConfirmationFullMessage = _webDriver.FindElement(pledgeCreatedConfirmationPanel).Text;
            pledgeID = pledgeConfirmationFullMessage.Substring(pledgeConfirmationFullMessage.Length - 6);
            return pledgeID;
        }

    }
}
