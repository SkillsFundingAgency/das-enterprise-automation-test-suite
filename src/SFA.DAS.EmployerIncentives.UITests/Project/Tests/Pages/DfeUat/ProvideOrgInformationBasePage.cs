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

        private By FieldSet => By.CssSelector("fieldset");

        protected RegistrationConfig registrationConfig;

        public ProvideOrgInformationBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) 
        {
            registrationConfig = context.GetRegistrationConfig<RegistrationConfig>();
        }

        protected void SelectRadioOptionByText(string forvalue, string text)
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElements(FieldSet).Single(x => x.GetAttribute("for").Contains(forvalue) && x.Text == text));
        }

    }
}
