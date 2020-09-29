using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.DfeUat
{
    public class ProvideReceivedDetailsPage : ProvideOrgInformationBasePage
    {
        protected override string PageTitle => "We have received your details";
        
        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        protected override By PageHeader => By.CssSelector("h1");

        private By ReturnToEasLink => By.CssSelector(".submission-message a");

        public ProvideReceivedDetailsPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public ApplicationCompletePage ReturnToEasPage()
        {
            frameHelper.SwitchFrameAndAction(() => 
            {
                formCompletionHelper.ClickElement(ReturnToEasLink);
            });
            
            return new ApplicationCompletePage(_context);
        }
    }
}
