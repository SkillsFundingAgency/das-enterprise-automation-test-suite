using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerSelectEmployerPage : BasePage
    {
        private PageInteractionHelper _pageInteractionHelper;
        private FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        public ChangeOfEmployerSelectEmployerPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        private By ChooseEmployerLink => By.LinkText("Select");
        protected override string PageTitle { get; }

        public ChangeOfEmployerConfirmNewEmployerPage SelectNewEmployer(int employerNumber = 0)
        {
            IList<IWebElement> employerLink = _pageInteractionHelper.FindElements(ChooseEmployerLink);
            _formCompletionHelper.ClickElement(employerLink[employerNumber]);
            
            return new ChangeOfEmployerConfirmNewEmployerPage(_context);
        }

    }
}
