using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages
{

    public class ApprenticesHomePage : InterimApprenitcepage
    {
        protected override string PageTitle => "Apprentices";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AddAnApprenticeLink => By.LinkText("Add an apprentice");
        private By YourCohortsLink => By.LinkText("Your cohorts");
        private By ManageYourApprenticesLink => By.LinkText("Manage your apprentices");

        protected override string Linktext => "Apprentices";

        public ApprenticesHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        internal ApprenticesHomePage(ScenarioContext context, bool navigate) : this(context)
        {
            this.navigate = navigate;
        }

        internal AddAnApprenitcePage AddAnApprentice()
        {
            formCompletionHelper.ClickElement(AddAnApprenticeLink);
            return new AddAnApprenitcePage(_context);
        }
    }
}

