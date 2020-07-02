using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class CreateAnAdvertPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Create an advert";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("[data-automation='continue-button']");

        public CreateAnAdvertPage(ScenarioContext context) : base(context) => _context = context;

        public WhatDoYouWantToCallThisAdvertPage CreateNewAdvert()
        {
            SelectRadioOptionByForAttribute("create-new");
            Continue();
            return new WhatDoYouWantToCallThisAdvertPage(_context);
        }
    }
}
