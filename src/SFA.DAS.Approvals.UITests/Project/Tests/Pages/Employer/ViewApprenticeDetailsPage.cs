using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ViewApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "View apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        private By InputBox => By.TagName("input");

        public ViewApprenticeDetailsPage(ScenarioContext context) : base(context) => _context = context;

        internal List<IWebElement> GetAllEditBoxes()
        {
            return pageInteractionHelper.FindElements(InputBox);
        }
    }
}
