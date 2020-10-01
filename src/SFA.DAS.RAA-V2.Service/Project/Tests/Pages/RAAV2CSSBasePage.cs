using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class RAAV2CSSBasePage : BasePage
    {
        protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
        protected readonly VacancyReferenceHelper vacancyReferenceHelper;
        protected readonly RAAV2DataHelper rAAV2DataHelper;
        protected readonly TabHelper tabHelper;
        protected readonly JavaScriptHelper javaScriptHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        protected readonly bool isRaaV2Employer;

        protected override By ContinueButton => By.CssSelector(".save-button");
       
        public RAAV2CSSBasePage(ScenarioContext context, bool verifypage = true) : base(context) 
        {
            isRaaV2Employer = context.ScenarioInfo.Tags.Contains("raa-v2e");
            vacancyReferenceHelper = context.GetValue<VacancyReferenceHelper>();
            vacancyTitleDataHelper = context.GetValue<VacancyTitleDatahelper>();
            rAAV2DataHelper = context.GetValue<RAAV2DataHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            tabHelper = context.Get<TabHelper>();
            javaScriptHelper = context.Get<JavaScriptHelper>();
            tableRowHelper = context.Get<TableRowHelper>();

            if (verifypage) { VerifyPage(); }
        }

        protected new RAAV2CSSBasePage SelectRadioOptionByForAttribute(string value)
        {
            base.SelectRadioOptionByForAttribute(value);
            return this;
        }
    }
}
