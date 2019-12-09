using OpenQA.Selenium;
using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class SelectOrganisationPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Which organisation is this vacancy for?";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly EmployerDataHelper _dataHelper;
        #endregion
        
        public SelectOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<EmployerDataHelper>();
            VerifyPage();
        }

        public EmployerNamePage SelectOrganisation()
        {
            _formCompletionHelper.ClickElement(() => _dataHelper.GetRandomElementFromListOfElements(_pageInteractionHelper.FindElements(RadioLabels)));
            _formCompletionHelper.Click(Continue);
            return new EmployerNamePage(_context);
        }
    }
}
