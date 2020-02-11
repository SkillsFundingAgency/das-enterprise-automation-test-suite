using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AddAPAYESchemePage : RegistrationBasePage
    {
        protected override string PageTitle => "Add a PAYE Scheme";
        private readonly ScenarioContext _context;

        #region Locators
        private By AddPayeRadioButton => By.CssSelector("label[for=want-to-add-paye-scheme]");
        private By DoNotAddPayeRadioButton => By.CssSelector("label[for=do-not-want-to-add-paye-scheme]");
        protected override By ContinueButton => By.Id("submit-add-a-paye-scheme-button");
        #endregion

        public AddAPAYESchemePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public GatewayInformPage AddPaye()
        {
            SelectAddPaye().
                Continue();
            return new GatewayInformPage(_context);
        }

        public MyAccountWithOutPaye DoNotAddPaye()
        {
            SelectDoNotAddPaye().
                Continue();
            return new MyAccountWithOutPaye(_context);
        }

        private AddAPAYESchemePage SelectAddPaye()
        {
            formCompletionHelper.ClickElement(AddPayeRadioButton);
            return this;
        }

        private AddAPAYESchemePage SelectDoNotAddPaye()
        {
            formCompletionHelper.ClickElement(DoNotAddPayeRadioButton);
            return this;
        }
    }
}