using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public abstract class EIBasePage : VerifyBasePage
    {
        #region Helpers and Context
        protected readonly EIDataHelper eIDataHelper;
        protected readonly EIConfig eIConfig;
        protected readonly RegistrationDataHelper registrationDataHelper;
        #endregion

        protected override By PageHeader => By.CssSelector("h1");

        protected override By ContinueButton => By.XPath("//button[contains(text(), 'Continue')]");

        protected EIBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            eIConfig = context.GetEIConfig<EIConfig>();
            eIDataHelper = context.Get<EIDataHelper>();
            registrationDataHelper = context.Get<RegistrationDataHelper>();
            if (verifypage) { VerifyPage(); }
        }
    }
}
