using OpenQA.Selenium;
using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public abstract class RAAV2CSSBasePage : BasePage
    {
        protected By Continue => By.CssSelector(".govuk-button");

        protected By RadioLabels => By.CssSelector(".govuk-radios__label");


        protected readonly EmployerDataHelper _dataHelper;
        protected readonly FormCompletionHelper _formCompletionHelper;

        public RAAV2CSSBasePage(ScenarioContext context) : base(context) 
        {
            _dataHelper = context.Get<EmployerDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
    }
}
