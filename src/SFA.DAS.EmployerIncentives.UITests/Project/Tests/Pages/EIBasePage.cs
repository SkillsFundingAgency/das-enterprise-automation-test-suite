using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public abstract class EIBasePage : VerifyBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected readonly EIDataHelper eIDataHelper;
        protected readonly EIConfig eIConfig;
        protected readonly RegistrationDataHelper registrationDataHelper;
        #endregion

        protected override By PageHeader => By.CssSelector("h1");

        protected override By ContinueButton => By.XPath("//button[contains(text(), 'Continue')]");

        private By ReturnToAccountHomeCTA => By.LinkText("Return to account home");

        protected EIBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            _context = context;
            eIConfig = context.GetEIConfig<EIConfig>();
            eIDataHelper = context.Get<EIDataHelper>();
            registrationDataHelper = context.Get<RegistrationDataHelper>();
            if (verifypage) { VerifyPage(); }
        }

        public HomePage ClickOnReturnToAccountHomeLink()
        {
            formCompletionHelper.Click(ReturnToAccountHomeCTA);
            return new HomePage(_context);
        }
    }
}
