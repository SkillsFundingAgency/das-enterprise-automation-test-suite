using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider.ManageFunding
{
    public class ProviderConfirmEmployerNonLevyPage : BasePage
    {
        protected override string PageTitle => "Confirm employer";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By ConfirmEmployerOptions => By.CssSelector(".govuk-radios__label");
        private By SaveAndContinueButton => By.CssSelector(".govuk-button");


        public ProviderConfirmEmployerNonLevyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        
        internal ProviderApprenticeshipTrainingPage confirmNonLevyEmployer()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmEmployerOptions, "confirm-yes");
            _formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderApprenticeshipTrainingPage(_context);
        }
    }
}
