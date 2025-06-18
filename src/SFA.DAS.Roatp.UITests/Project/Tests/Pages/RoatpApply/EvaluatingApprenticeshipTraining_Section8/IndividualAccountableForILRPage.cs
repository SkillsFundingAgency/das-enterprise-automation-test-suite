using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
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
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Full name", RoatpApplyDataHelpers.FullName);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Email", RoatpApplyDataHelpers.Email);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Contact number", RoatpApplyDataHelpers.ContactNumber);
            Continue();
            return new ApplicationOverviewPage(context);
        }
    }
}
