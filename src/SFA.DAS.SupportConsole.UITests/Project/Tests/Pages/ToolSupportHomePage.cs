using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class ToolSupportHomePage : ToolSupportBasePage
    {
        protected override string PageTitle => "DAS Tools Support";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        #region Locators
        private By HomeHeading => By.LinkText("support");
        protected By PauseApprenticeshipsLink => By.Id("pauseApprenticeship");
        protected By ResumeApprenticeshipsLink => By.Id("resumeApprenticeship");
        protected By StopApprenticeshipsLink => By.Id("stopApprenticeship");
        #endregion

        public ToolSupportHomePage(ScenarioContext context) : base(context) => _context = context;

        public SearchForApprenticeshipPage ClickPauseApprenticeshipsLink()
        {
            formCompletionHelper.Click(PauseApprenticeshipsLink);
            return new SearchForApprenticeshipPage(_context);
        }

        public SearchForApprenticeshipPage ClickResumeApprenticeshipsLink()
        {
            formCompletionHelper.Click(ResumeApprenticeshipsLink);
            return new SearchForApprenticeshipPage(_context);
        }

        public SearchForApprenticeshipPage ClickStopApprenticeshipsLink()
        {
            formCompletionHelper.Click(StopApprenticeshipsLink);
            return new SearchForApprenticeshipPage(_context);
        }

        public SearchHomePage GoToHomePage()
        {
            formCompletionHelper.ClickElement(HomeHeading);
            return new SearchHomePage(_context);
        }

    }
}
