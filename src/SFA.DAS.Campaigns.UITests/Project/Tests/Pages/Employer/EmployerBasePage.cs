using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public abstract class EmployerBasePage : HubBasePage
    {
        protected override By PageHeader => SubPageHeader;

        protected By AreTheyRightForYou => By.CssSelector("a[href='/employers/are-they-right-for-you-employers']");

        protected By HowDoTheyWork => By.CssSelector("a[href= '/employers/how-do-they-work-for-employers']");

        protected By SettingItUp => By.CssSelector("a[href='/employers/setting-it-up']");

        protected EmployerBasePage(ScenarioContext context) : base(context)  { }

        public EmployerAreTheyRightForYouPage NavigateToAreTheyRightForYouPage()
        {
            formCompletionHelper.ClickElement(AreTheyRightForYou);
            return new EmployerAreTheyRightForYouPage(context);
        }

        public EmployerHowDoTheyWorkPage ClickHowDoTheyWorkLink()
        {
            formCompletionHelper.ClickElement(HowDoTheyWork);
            return new EmployerHowDoTheyWorkPage(context);
        }

        public SettingItUpPage ClickSettingUpLink()
        {
            formCompletionHelper.ClickElement(SettingItUp);
            return new SettingItUpPage(context);
        }
    }
}