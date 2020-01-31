using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ActivateYourAccountPage : BasePage
    {
        protected override string PageTitle => "Activate your account";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FAADataHelper _dataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By ActivationCode => By.Id("ActivationCode");
        private By ActivateAccount => By.Id("activate-button");

        public FAA_ActivateYourAccountPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<FAADataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public FAA_ActivateYourAccountPage2 EnterActivationCode()
        {
            _formCompletionHelper.EnterText(ActivationCode, _dataHelper.ActivationCode);
            _formCompletionHelper.Click(ActivateAccount);
            return new FAA_ActivateYourAccountPage2(_context);
        }
    }
}