using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{

    public class WithdrawnFromAContractWithRoToPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation been removed from the Register of Training Organisations (RoTO) in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WithdrawnFromAContractWithRoToPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FundingRemovedFromEducationBodiesPage SelectNoForWithdrawnFromAContractWithRoTo()
        {
            SelectNoAndContinue();
            return new FundingRemovedFromEducationBodiesPage(_context);
        }
    }

    public class WithdrawnFromAContractWithPublicBodyPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation withdrawn from a contract with a public body in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WithdrawnFromAContractWithPublicBodyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WithdrawnFromAContractWithRoToPage SelectYesEnterInformationForContractWithdrawnWithPublicBody()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.WithdrawnFromAContractWithPublicBody);
            return new WithdrawnFromAContractWithRoToPage(_context);
        }
    }
}
