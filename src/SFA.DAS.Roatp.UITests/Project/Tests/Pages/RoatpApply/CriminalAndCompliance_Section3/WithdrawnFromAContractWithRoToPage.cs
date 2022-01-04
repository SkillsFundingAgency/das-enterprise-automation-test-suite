using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class WithdrawnFromAContractWithRoToPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation been removed from the Register of Training Organisations (RoTO) in the last 3 years?";

        #region Helpers and Context
        
        #endregion

        public WithdrawnFromAContractWithRoToPage(ScenarioContext context) : base(context) => VerifyPage();

        public FundingRemovedFromEducationBodiesPage SelectNoForWithdrawnFromAContractWithRoTo()
        {
            SelectNoAndContinue();
            return new FundingRemovedFromEducationBodiesPage(context);
        }
    }
}
