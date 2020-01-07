using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
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

        public ImportantDatesPage ChooseAddress(bool isEmployerAddress)
        {
            if (isEmployerAddress)
            {
                SelectRadioOptionByForAttribute("OtherLocation_1");
            }
            else
            {
                DifferentLocation();
            }
            Continue();
            return new ImportantDatesPage(_context);
        }

        private void DifferentLocation()
        {
            SelectRadioOptionByForAttribute("other-location");
            formCompletionHelper.ClickElement(() => { formCompletionHelper.EnterText(AddressLine1, dataHelper.EmployerAddress); return _pageInteractionHelper.FindElement(MenuItems); });
        }
    }
}
