using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.EvaluatingApprenticeshipTraining_Section8
{
    public class IndividualAccountableForILRPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Who is the individual accountable for submitting ILR data for your organisation?";
        protected static By LabelCssSelector => By.CssSelector(".govuk-form-group");

        public IndividualAccountableForILRPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage EnterDetailsForIndividualAccountable()
        {
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Full name", applydataHelpers.FullName);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Email", applydataHelpers.Email);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Contact number", applydataHelpers.ContactNumber);
            Continue();
            return new ApplicationOverviewPage(context);
        }
    }
}
