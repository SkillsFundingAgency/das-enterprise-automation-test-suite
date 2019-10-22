using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages
{
    public class RAA_EmployerSelection : BasePage
    {
        protected override string PageTitle => "Select an employer for your vacancy";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1Config _config;
        #endregion

        private By SelectAnEmployer => By.LinkText("Select employer");

        public RAA_EmployerSelection(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetRAAV1Config<RAAV1Config>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public RAA_EmployerInformation SelectAndEmployer()
        {
            _formCompletionHelper.Click(SelectAnEmployer);
            return new RAA_EmployerInformation(_context);
        }
    }
}
