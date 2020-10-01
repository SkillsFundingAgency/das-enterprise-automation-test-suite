using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.DfeUat
{
    public abstract class ProvideOrgInformationBasePage : EIBasePage
    {
        protected override By PageHeader => By.CssSelector("h2");

        protected virtual By Options => By.CssSelector(".radio-label");

        protected override By ContinueButton => By.CssSelector(".nextbutton");
        
        protected RegistrationConfig registrationConfig;

        public ProvideOrgInformationBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) 
        {
            registrationConfig = context.GetRegistrationConfig<RegistrationConfig>();
        }

        protected override void Continue() => formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(ContinueButton), false);

        protected void SelectOptionByText(string forvalue, string text)
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElements(Options).Single(x => x.GetAttribute("for").Contains(forvalue) && x.Text == text), false);
        }

    }
}
