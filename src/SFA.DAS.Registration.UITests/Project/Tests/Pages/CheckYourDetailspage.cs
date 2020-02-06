using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CheckYourDetailsPage : BasePage
    {
        protected override string PageTitle => "Check your details";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By ChangeOrganisationName() => By.CssSelector("a[href=/accounts/organisations]");

        private By ChangePayeDetails() => By.CssSelector("a[href=/accounts/amendPaye]");

        protected override By ContinueButton => By.Id("continue");

        public CheckYourDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public WhenDoYouWantToViewEmpAgreementPage ContinueToAboutYourAgreementPage()
        {
            Continue();
            return new WhenDoYouWantToViewEmpAgreementPage(_context);
        }
    }
}