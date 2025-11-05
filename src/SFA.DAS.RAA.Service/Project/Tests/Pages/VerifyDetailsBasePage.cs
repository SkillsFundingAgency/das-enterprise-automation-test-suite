using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public abstract class VerifyDetailsBasePage(ScenarioContext context, bool verifypage = true) : RaaBasePage(context, verifypage)
    {
        protected virtual By EmployerName { get; }

        protected virtual By EmployerNameInAboutTheEmployerSection { get; }

        protected virtual By DisabilityConfident { get; }

        protected void VerifyEmployerName()
        {
            var empName = objectContext.GetEmployerNameAsShownInTheAdvert();
            VerifyElement(EmployerName, empName);
            VerifyElement(EmployerNameInAboutTheEmployerSection, empName);
        }

        protected void VerifyDisabilityConfident() => VerifyElement(DisabilityConfident);

        public void RAAQASignOut()
        {
            formCompletionHelper.ClickElement(By.CssSelector("#navigation a[data-automation='sign-out']"));
            if (EnvironmentConfig.IsPPEnvironment && !(new CheckASVacancyQaLandingPage(context).IsPageDisplayed()))
            {
                var userName = context.GetUser<VacancyQaUser>().Username;
                var accountRowXPath = $"//div[contains(concat(' ', normalize-space(@class), ' '), ' table-row ')][.//small[normalize-space(text())='{userName}']]";

                formCompletionHelper.ClickElement(By.XPath(accountRowXPath));
            }
        }
    }
}
