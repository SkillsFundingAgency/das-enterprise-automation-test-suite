using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfimCloneVacancyDatePage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Vacancy succesfully cloned";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Info => By.CssSelector(".info-summary");
        private By ChangeTitle => By.CssSelector("a[data-automation='link-employer-name']");        

        public ConfimCloneVacancyDatePage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            VerifyPage(() => pageInteractionHelper.FindElements(Info));
        }

        public WhatDoYouWantToCallThisAdvertPage UpdateTitle()
        {
            formCompletionHelper.Click(ChangeTitle);
            return new WhatDoYouWantToCallThisAdvertPage(_context);
        }
    }
}
