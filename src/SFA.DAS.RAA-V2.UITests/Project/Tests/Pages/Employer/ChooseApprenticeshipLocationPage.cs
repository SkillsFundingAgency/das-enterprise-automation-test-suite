using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ChooseApprenticeshipLocationPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Where will the apprentice work?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By AddressLine1 => By.Id("AddressLine1");
        
        private By MenuItems => By.CssSelector(".ui-menu-item");

        public ChooseApprenticeshipLocationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public ImportantDatesPage ChooseAddress(bool employerAddress)
        {
            if (employerAddress)
            {
                _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "OtherLocation_1");
            }
            else
            {
                DifferentLocation();
            }
            _formCompletionHelper.Click(Continue);
            return new ImportantDatesPage(_context);
        }

        private void DifferentLocation()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "other-location");
            _formCompletionHelper.ClickElement(() => { _formCompletionHelper.SendKeys(AddressLine1, _dataHelper.EmployerAddress); return _pageInteractionHelper.FindElement(MenuItems); });
            _formCompletionHelper.EnterText(AddressLine1, _dataHelper.EmployerAddress);
        }
    }
}
