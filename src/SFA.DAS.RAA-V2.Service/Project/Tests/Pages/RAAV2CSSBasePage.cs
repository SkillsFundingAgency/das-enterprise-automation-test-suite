using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class RAAV2CSSBasePage : VerifyBasePage
    {
        protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
        protected readonly VacancyReferenceHelper vacancyReferenceHelper;
        protected readonly RAAV2DataHelper rAAV2DataHelper;
        protected readonly bool isRaaV2Employer;

        protected override By ContinueButton => By.CssSelector(".save-button");
       
        public RAAV2CSSBasePage(ScenarioContext context, bool verifypage = true) : base(context) 
        {
            isRaaV2Employer = tags.Contains("raa-v2e");
            vacancyReferenceHelper = context.GetValue<VacancyReferenceHelper>();
            vacancyTitleDataHelper = context.GetValue<VacancyTitleDatahelper>();
            rAAV2DataHelper = context.GetValue<RAAV2DataHelper>();

            if (verifypage) { VerifyPage(); }
        }

        protected new RAAV2CSSBasePage SelectRadioOptionByForAttribute(string value)
        {
            base.SelectRadioOptionByForAttribute(value);
            return this;
        }
    }
}
