using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class ManageApprenticeshipsPage : TransfersBasePage
    {
        public ManageApprenticeshipsPage(ScenarioContext context) : base(context) => _context = context;

        protected override By PageHeader => By.Id("proposition-name");
        protected override string PageTitle => "Manage apprenticeships";

        public bool CheckPageTitle()
        {

            bool pageTitleOK = VerifyPage(PageHeader, PageTitle);
            return pageTitleOK;

        }

        #region Helpers and Context
        private readonly ScenarioContext _context;

        #endregion

        //protected override By ContinueButton => By.CssSelector(".button");

        //private By GoToHomePageRadioButton => By.CssSelector(".selection-button-radio");

        //public ConnectionConfirmedPage(ScenarioContext context) : base(context) => _context = context;


        //{
        //    formCompletionHelper.SelectRadioOptionByText(GoToHomePageRadioButton, "Go back to the homepage");
        //    Continue();
        //    return new HomePage(_context);
        //}
    }
}