using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public abstract class RAAV2CSSBasePage : BasePage
    {
        protected By Continue => By.CssSelector(".govuk-button");

        protected By RadioLabels => By.CssSelector(".govuk-radios__label");

        public RAAV2CSSBasePage(ScenarioContext context) : base(context) { }
    }
}
