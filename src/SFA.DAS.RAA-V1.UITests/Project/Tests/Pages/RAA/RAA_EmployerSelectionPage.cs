using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_EmployerSelectionPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Select an employer for your vacancy";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By SelectEmployerLinks => By.CssSelector("a");

        public RAA_EmployerSelectionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public RAA_EmployerInformationPage SelectAnEmployer()
        {
            var links = _pageInteractionHelper.GetLinks(SelectEmployerLinks, "Select employer");
            formCompletionHelper.ClickElement(dataHelper.Employers(links));
            return new RAA_EmployerInformationPage(_context);
        }
    }
}
