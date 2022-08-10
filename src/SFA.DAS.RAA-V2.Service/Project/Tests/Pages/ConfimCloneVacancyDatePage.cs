using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfimCloneVacancyDatePage : Raav2BasePage
    {
        protected override string PageTitle => "Advert succesfully cloned";

        private By Info => By.CssSelector(".govuk-notification-banner__heading");
        private By ChangeTitle => By.CssSelector("a[data-automation='change-title']");        

        public ConfimCloneVacancyDatePage(ScenarioContext context) : base(context, false) => VerifyPage(() => pageInteractionHelper.FindElements(Info));

        public WhatDoYouWantToCallThisAdvertPage UpdateTitle()
        {
            formCompletionHelper.Click(ChangeTitle);
            return new WhatDoYouWantToCallThisAdvertPage(context);
        }
    }
}
