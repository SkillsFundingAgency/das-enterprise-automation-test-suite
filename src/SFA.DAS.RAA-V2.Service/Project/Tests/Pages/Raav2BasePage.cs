using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class Raav2BasePage : VerifyBasePage
    {
        protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
        protected readonly VacancyReferenceHelper vacancyReferenceHelper;
        protected readonly RAAV2DataHelper rAAV2DataHelper;
        protected readonly bool isRaaV2Employer;
        protected readonly bool IsTraineeship;

        protected override By ContinueButton => By.CssSelector(".save-button");

        protected override By PageHeader => By.CssSelector($"{PageHeaderSelector}, .govuk-label--xl");

        protected virtual By SaveAndContinueButton => By.ClassName("govuk-button");

        private By CancelLink => By.LinkText("Cancel");

        public Raav2BasePage(ScenarioContext context, bool verifypage = true) : base(context) 
        {
            isRaaV2Employer = tags.Contains("raa-v2e");
            IsTraineeship = tags.Contains("rat-p");
            vacancyReferenceHelper = context.GetValue<VacancyReferenceHelper>();
            vacancyTitleDataHelper = context.GetValue<VacancyTitleDatahelper>();
            rAAV2DataHelper = context.GetValue<RAAV2DataHelper>();

            if (verifypage) VerifyPage();
        }

        protected virtual void SaveAndContinue() => formCompletionHelper.ClickButtonByText(SaveAndContinueButton, "Save and continue");

        protected void VerifyPanelTitle(string text) => pageInteractionHelper.VerifyText(PanelTitle, text);

        protected new Raav2BasePage SelectRadioOptionByForAttribute(string value)
        {
            base.SelectRadioOptionByForAttribute(value);
            return this;
        }

        public void EmployerCancelAdvert() => formCompletionHelper.Click(CancelLink);
    }
}
