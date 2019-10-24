using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_EmployerSelection : BasePage
    {
        protected override string PageTitle => "Select an employer for your vacancy";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1Config _config;
        private readonly RAADataHelper _dataHelper;
        #endregion

        private By SelectEmployerLinks => By.CssSelector("a");

        public RAA_EmployerSelection(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetRAAV1Config<RAAV1Config>();
            _dataHelper = context.Get<RAADataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public RAA_EmployerInformation SelectAnEmployer()
        {
            var links = _pageInteractionHelper.GetLinks(SelectEmployerLinks, "Select employer");
            _formCompletionHelper.ClickElement(_dataHelper.Employers(links));
            return new RAA_EmployerInformation(_context);
        }
    }
}
