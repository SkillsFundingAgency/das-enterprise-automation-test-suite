using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ChooseApprenticeshipLocationPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Where will the apprentice work?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By AddressLine1 => By.Id("AddressLine1");
        
        private By MenuItems => By.CssSelector(".ui-menu-item");

        private By Postcode => By.CssSelector("#Postcode");

        private By EmployerLocation => By.CssSelector("label[for='OtherLocation_1']");

        public ChooseApprenticeshipLocationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public ImportantDatesPage ChooseAddress(bool isEmployerAddress)
        {
            if (isEmployerAddress)
            {
                SelectRadioOptionByForAttribute("OtherLocation_1");
                var empLocation = _pageInteractionHelper.GetText(EmployerLocation);
                SetEmployerLocation(empLocation);
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
            var empLocation = _pageInteractionHelper.GetText(Postcode);
            SetEmployerLocation(empLocation);
        }

        private void SetEmployerLocation(string value)
        {
            _objectContext.SetEmployerLocation(value);
        }
    }
}
