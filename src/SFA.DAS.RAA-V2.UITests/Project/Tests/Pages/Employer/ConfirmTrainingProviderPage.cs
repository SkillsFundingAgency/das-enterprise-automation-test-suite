using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Confirm the training provider";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;

        #endregion

        public ConfirmTrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ChooseTrainingProviderPage ConfirmAndContinue()
        {
            _formCompletionHelper.Click(Continue);
            return new ChooseTrainingProviderPage(_context);
        }
    }



    

}
