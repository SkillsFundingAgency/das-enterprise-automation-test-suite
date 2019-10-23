using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
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
        private readonly RAAV1DataHelper _dataHelper;
        #endregion

        private By SelectAnEmployer => By.CssSelector("a");

        public RAA_EmployerSelection(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetRAAV1Config<RAAV1Config>();
            _dataHelper = context.Get<RAAV1DataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public RAA_EmployerInformation SelectAndEmployer()
        {
            var links = _pageInteractionHelper.GetLinks(SelectAnEmployer, "Select employer");
            _formCompletionHelper.ClickElement(_dataHelper.Employers(links));
            return new RAA_EmployerInformation(_context);
        }
    }
}
