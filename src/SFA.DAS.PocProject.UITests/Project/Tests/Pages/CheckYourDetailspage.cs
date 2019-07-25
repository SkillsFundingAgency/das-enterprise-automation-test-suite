using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.Pages
{
    public class CheckYourDetailspage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By ChangeOrganisationName() => By.CssSelector("a[href=/accounts/organisations]");

        private By ChangePayeDetails() => By.CssSelector("a[href=/accounts/amendPaye]");

        private By ContinueButton => By.Id("continue");

        public CheckYourDetailspage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override string PageTitle => "Check your details";

        public void TheseDetailsAreCorrect()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
        }
    }
}