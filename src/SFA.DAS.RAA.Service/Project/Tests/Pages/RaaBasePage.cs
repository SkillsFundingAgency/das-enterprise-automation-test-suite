using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public abstract class RaaBasePage : VerifyBasePage
    {
        protected readonly VacancyTitleDatahelper vacancyTitleDataHelper;
        protected readonly VacancyReferenceHelper vacancyReferenceHelper;
        protected readonly RAADataHelper rAADataHelper;

        protected readonly AdvertDataHelper advertDataHelper;
        protected readonly bool isRaaEmployer;

        protected override By ContinueButton => By.CssSelector(".save-button");

        protected override By PageHeader => By.CssSelector($"{PageHeaderSelector}, .govuk-label--xl");

        protected virtual By SaveAndContinueButton => By.ClassName("govuk-button");

        private static By CancelLink => By.LinkText("Cancel");

        protected static By MultipleCandidateFeedback => By.CssSelector("#provider-multiple-candidate-feedback");
        protected static By CandidateFeedback => By.CssSelector("#CandidateFeedback");

        public RaaBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            isRaaEmployer = tags.Contains("raaemployer");
            vacancyReferenceHelper = context.GetValue<VacancyReferenceHelper>();
            vacancyTitleDataHelper = context.GetValue<VacancyTitleDatahelper>();
            rAADataHelper = context.GetValue<RAADataHelper>();
            advertDataHelper = context.GetValue<AdvertDataHelper>();

            if (verifypage) VerifyPage();
        }
        protected bool IsFoundationAdvert => context.ContainsKey("isFoundationAdvert") && (bool)context["isFoundationAdvert"];
        private static By FoundationTag => By.CssSelector(".govuk-tag--pink");
        public void CheckFoundationTag()
        {
            var expectedFoundationTag = "Foundation";
            var actualFoundationTag = pageInteractionHelper.GetText(FoundationTag).Trim();
            pageInteractionHelper.VerifyText(actualFoundationTag, expectedFoundationTag);
        }

        protected virtual void SaveAndContinue() => formCompletionHelper.ClickButtonByText(SaveAndContinueButton, "Save and continue");

        protected void VerifyPanelTitle(string text) => pageInteractionHelper.VerifyText(PanelTitle, text);

        protected new RaaBasePage SelectRadioOptionByForAttribute(string value)
        {
            base.SelectRadioOptionByForAttribute(value);
            return this;
        }

        public void EmployerCancelAdvert() => formCompletionHelper.Click(CancelLink);
    }
}
