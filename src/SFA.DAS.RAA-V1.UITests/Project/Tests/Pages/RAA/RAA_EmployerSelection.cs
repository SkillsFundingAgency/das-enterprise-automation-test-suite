using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_EmployerSelection : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Select an employer for your vacancy";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By SelectEmployerLinks => By.CssSelector("a");

        public RAA_EmployerSelection(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public RAA_EmployerInformation SelectAnEmployer()
        {
            var links = _pageInteractionHelper.GetLinks(SelectEmployerLinks, "Select employer");
            formCompletionHelper.ClickElement(dataHelper.Employers(links));
            return new RAA_EmployerInformation(_context);
        }
    }
}
