using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class VerifyDetailsBasePage : Raav2BasePage
    {
        protected virtual By EmployerName { get; }

        protected virtual By EmployerNameInAboutTheEmployerSection { get; }

        protected virtual By DisabilityConfident { get; }

        public VerifyDetailsBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        protected void VerifyEmployerName()
        {
            var empName = objectContext.GetEmployerNameAsShownInTheAdvert();
            VerifyElement(EmployerName, empName);
            VerifyElement(EmployerNameInAboutTheEmployerSection, empName);
        }

        protected void VerifyDisabilityConfident() => VerifyElement(DisabilityConfident);

        public void RAAV2QASignOut() => formCompletionHelper.ClickElement(By.CssSelector("#navigation a[data-automation='sign-out']"));
    }
}
