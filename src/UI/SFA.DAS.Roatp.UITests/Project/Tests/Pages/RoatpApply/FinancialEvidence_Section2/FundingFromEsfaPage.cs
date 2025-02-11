using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class FundingFromEsfaPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation expect its funding from DfE to be less than 5% of its total annual turnover?";

        public FundingFromEsfaPage(ScenarioContext context) : base(context) => VerifyPage();

        public FinancialEvidencePage SelectNoOnFundingFromEsfaAndContinue()
        {
            SelectRadioOptionByText("No");
            Continue();
            return new FinancialEvidencePage(context);
        }
    }
}
