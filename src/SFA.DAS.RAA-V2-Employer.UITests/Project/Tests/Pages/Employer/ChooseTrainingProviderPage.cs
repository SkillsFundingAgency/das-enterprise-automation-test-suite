using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class ChooseTrainingProviderPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Have you found a training provider?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly RAAV2EmployerDataHelper _dataHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By TrainingProviderSearch => By.CssSelector("#TrainingProviderSearch");

        private By FirstOption => By.CssSelector("#TrainingProviderSearch__option--0");

        public ChooseTrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<RAAV2EmployerDataHelper>();
        }

        public ConfirmTrainingProviderPage ChooseTrainingProvider()
        {
            SelectRadioOptionByForAttribute("found_yes");

            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(TrainingProviderSearch, _dataHelper.Provider); return _pageInteractionHelper.FindElement(FirstOption); });

            Continue();

            return new ConfirmTrainingProviderPage(_context);
            
        }
    }
}
