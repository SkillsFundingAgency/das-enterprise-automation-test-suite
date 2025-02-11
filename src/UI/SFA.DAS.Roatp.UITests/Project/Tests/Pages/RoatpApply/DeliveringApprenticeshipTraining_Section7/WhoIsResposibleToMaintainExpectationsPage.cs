using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class WhoIsResposibleToMaintainExpectationsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Tell us who's responsible for maintaining these expectations for quality and high standards in apprenticeship training";

        protected static By LabelCssSelector => By.CssSelector(".govuk-form-group");

        public WhoIsResposibleToMaintainExpectationsPage(ScenarioContext context) : base(context) => VerifyPage();

        public HowAreTheyCommunicatedToEmployeesPage EnterDetails()
        {
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Full name", RoatpApplyDataHelpers.FullName);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Email", RoatpApplyDataHelpers.Email);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Contact number", RoatpApplyDataHelpers.ContactNumber);
            Continue();
            return new HowAreTheyCommunicatedToEmployeesPage(context);
        }
    }
}