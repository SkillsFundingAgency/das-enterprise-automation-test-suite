using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Common
{
    public abstract class VerifyDetailsBasePage : BasePage
    {
        private readonly ObjectContext _objectContext;

        protected readonly RAAV2EmployerDataHelper rAAV2EmployerdataHelper;

        protected virtual By EmployerName { get; }

        protected virtual By EmployerNameInAboutTheEmployerSection { get; }

        protected virtual By DisabilityConfident { get; }

        public VerifyDetailsBasePage(ScenarioContext context) : base(context)
        {
            _objectContext = context.Get<ObjectContext>();
            rAAV2EmployerdataHelper = context.Get<RAAV2EmployerDataHelper>();
        }

        protected void VerifyEmployerName()
        {
            var empName = _objectContext.GetEmployerName();
            VerifyPage(EmployerName, empName);
            VerifyPage(EmployerNameInAboutTheEmployerSection, empName);
        }

        protected void VerifyDisabilityConfident()
        {
            VerifyPage(DisabilityConfident);
        }
    }
}
