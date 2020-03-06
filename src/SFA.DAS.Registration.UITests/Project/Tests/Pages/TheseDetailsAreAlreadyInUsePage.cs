using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class TheseDetailsAreAlreadyInUsePage : RegistrationBasePage
    {
        protected override string PageTitle => "These details are already in use";
        private readonly ScenarioContext _context;

        #region Locators
        protected override By ContinueButton => By.Id("search_again");
        #endregion

        public TheseDetailsAreAlreadyInUsePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AddAPAYESchemePage CickUseDifferentDetailsButtonInTheseDetailsAreAlreadyInUsePage()
        {
            Continue();
            return new AddAPAYESchemePage(_context);
        }

        public AddAPAYESchemePage CickBackLinkInTheseDetailsAreAlreadyInUsePage()
        {
            NavigateBack();
            return new AddAPAYESchemePage(_context);
        }
    }
}
