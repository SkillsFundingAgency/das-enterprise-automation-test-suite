using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class OtherSubsidiaryCompaniesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your UK ultimate parent company have other active subsidiary companies?";

        public OtherSubsidiaryCompaniesPage(ScenarioContext context) : base(context) => VerifyPage();

        public UploadUltimateParentCompanysFinancialsCoveringLastTwelveMonthsPage ClickNoOnOtherSubsidiaryCompanies()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new UploadUltimateParentCompanysFinancialsCoveringLastTwelveMonthsPage(context);
        }
    }
}
