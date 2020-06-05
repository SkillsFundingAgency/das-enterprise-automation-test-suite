using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class VerifyDetailsBasePage : RAAV2CSSBasePage
    {
        protected virtual By EmployerName { get; }

        protected virtual By EmployerNameInAboutTheEmployerSection { get; }

        protected virtual By DisabilityConfident { get; }

        public VerifyDetailsBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }
    
        protected void VerifyEmployerName()
        {
            var empName = objectContext.GetEmployerName();
            VerifyPage(EmployerName, empName);
            VerifyPage(EmployerNameInAboutTheEmployerSection, empName);
        }

        protected void VerifyDisabilityConfident() => VerifyPage(DisabilityConfident);
    }
}
