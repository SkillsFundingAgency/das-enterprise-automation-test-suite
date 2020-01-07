using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class RAAV2CSSBasePage : BasePage
    {
        protected By RadioLabels => By.CssSelector(".govuk-radios__label");

        protected readonly RAAV2EmployerDataHelper dataHelper;
        protected readonly FormCompletionHelper formCompletionHelper;

        public RAAV2CSSBasePage(ScenarioContext context) : base(context) 
        {
            dataHelper = context.Get<RAAV2EmployerDataHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected RAAV2CSSBasePage SelectRadioOptionByForAttribute(string value)
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, value);
            return this;
        }
    }
}
