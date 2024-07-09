using OpenQA.Selenium;
using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class CreateAnAdvertPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Create an advert";

        protected override By ContinueButton => By.CssSelector("[data-automation='continue-button']");

        public WhatDoYouWantToCallThisAdvertPage CreateNewAdvert()
        {
            SelectRadioOptionByForAttribute("create-new");
            Continue();
            return new WhatDoYouWantToCallThisAdvertPage(context);
        }
    }
}
