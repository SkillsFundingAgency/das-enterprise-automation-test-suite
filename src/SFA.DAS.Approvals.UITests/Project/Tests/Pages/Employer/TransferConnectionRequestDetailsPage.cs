using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class TransferConnectionRequestDetailsPage : BasePage
    {
        protected override string PageTitle => "Connection request details";
        
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        private By DoYouWishToConnectToThisEmpoyerOptions => By.CssSelector(".selection-button-radio");
        private By ContinueButton => By.CssSelector(".button");

        public TransferConnectionRequestDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }
        internal ConnectionConfirmedPage AcceptTransferConnectionRequest()
        {
            _formCompletionHelper.SelectRadioOptionByText(DoYouWishToConnectToThisEmpoyerOptions, "Yes, I want to approve the connection request");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ConnectionConfirmedPage(_context);
        }

    }
}