using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages
{
    public class PAYESchemeAddedPage : RegistrationBasePage
    {
        protected override string PageTitle => $"{objectContext.GetGatewayPaye(1)} has been added";
        protected override By PageHeader => By.CssSelector(".bold-large");
        protected override By ContinueButton => By.Id("accept");
        private readonly ScenarioContext _context;

        public PAYESchemeAddedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HomePage SelectContinueAccountSetupInPAYESchemeAddedPage()
        {
            SelectRadioOptionByForAttribute("choice3");
            Continue();
            return new HomePage(_context);
        }
    }
}
