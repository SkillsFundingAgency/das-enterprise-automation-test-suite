using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public abstract class VRFBasePage : EIBasePage
    {
        #region Locators
        protected override By PageHeader => By.CssSelector("h2");
        protected virtual By RadioOptions => By.CssSelector(".radio-label");
        protected override By ContinueButton => By.CssSelector(".nextbutton, .nextText");
        protected virtual By CheckboxOptions => By.CssSelector(".checkbox-label");
        protected virtual By ContactEmail => By.CssSelector("#contact_remittance_email");
        protected RegistrationConfig registrationConfig;
        #endregion

        public VRFBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage)
        {
            registrationConfig = context.GetRegistrationConfig<RegistrationConfig>();
        }

        protected override void Continue() => formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(ContinueButton), false);

        protected void SelectOptionByText(string forvalue, string text)
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElements(RadioOptions).Single(x => x.GetAttribute("for").Contains(forvalue) && x.Text == text), false);
        }

        protected void SelectCheckBoxByText(string forvalue, string text)
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElements(CheckboxOptions).Single(x => x.GetAttribute("for").Contains(forvalue) && x.Text == text), false);
        }
    }
}
