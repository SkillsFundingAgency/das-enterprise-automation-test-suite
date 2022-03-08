using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
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

        private By PageHeader_Label => By.CssSelector(".govuk-label--xl");

        private By CancelLink => By.LinkText("Cancel");

        public RAAV2CSSBasePage(ScenarioContext context, bool verifypage = true) : base(context) 
        {
            isRaaV2Employer = tags.Contains("raa-v2e");
            vacancyReferenceHelper = context.GetValue<VacancyReferenceHelper>();
            vacancyTitleDataHelper = context.GetValue<VacancyTitleDatahelper>();
            rAAV2DataHelper = context.GetValue<RAAV2DataHelper>();

            if (verifypage) 
            {
                if (pageInteractionHelper.IsElementDisplayed(PageHeader)) VerifyPage();
                else VerifyPage(PageHeader_Label, PageTitle);
            }
        }

        protected void VerifyPanelTitle(string text) => pageInteractionHelper.VerifyText(PanelTitle, text);

        protected new RAAV2CSSBasePage SelectRadioOptionByForAttribute(string value)
        {
            base.SelectRadioOptionByForAttribute(value);
            return this;
        }

        public void EmployerCancelAdvert() => formCompletionHelper.Click(CancelLink);
    }
}
