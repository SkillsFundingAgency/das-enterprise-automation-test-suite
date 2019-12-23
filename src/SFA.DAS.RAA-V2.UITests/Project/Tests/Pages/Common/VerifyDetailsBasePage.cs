using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Common
{
    public abstract class VerifyDetailsBasePage : BasePage
    {
        private readonly ObjectContext _objectContext;

        protected abstract By EmployerName { get; }

        protected abstract By EmployerNameInAboutTheEmployerSection { get; }

        protected abstract By DisabilityConfident { get; }

        public VerifyDetailsBasePage(ScenarioContext context) : base(context)
        {
            _objectContext = context.Get<ObjectContext>();
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
