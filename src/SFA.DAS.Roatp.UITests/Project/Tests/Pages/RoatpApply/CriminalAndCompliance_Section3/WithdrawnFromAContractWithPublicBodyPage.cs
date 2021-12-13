using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class WithdrawnFromAContractWithPublicBodyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation withdrawn from a contract with a public body in the last 3 years?";

        public WithdrawnFromAContractWithPublicBodyPage(ScenarioContext context) : base(context) => VerifyPage();

        public WithdrawnFromAContractWithRoToPage SelectYesEnterInformationForContractWithdrawnWithPublicBody()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.WithdrawnFromAContractWithPublicBody);
            return new WithdrawnFromAContractWithRoToPage(_context);
        }
    }
}
