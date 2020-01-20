using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class RAAV2CSSBasePage : BasePage
    {
        protected readonly RAAV2DataHelper dataHelper;
        protected readonly FormCompletionHelper formCompletionHelper;

        public RAAV2CSSBasePage(ScenarioContext context) : base(context) 
        {
            dataHelper = context.Get<RAAV2DataHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected new RAAV2CSSBasePage SelectRadioOptionByForAttribute(string value)
        {
            SelectRadioOptionByForAttribute(value);
            return this;
        }
    }
}
