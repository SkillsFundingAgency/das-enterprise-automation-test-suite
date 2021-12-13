using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class WhosInControlUnspentCriminalConvictionsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "any unspent criminal convictions?";

        public WhosInControlUnspentCriminalConvictionsPage(ScenarioContext context) : base(context) => VerifyPage();

        public WhosInControlFailedToPayBackFundsPage SelectYesEnterInformationForUnspentCriminalConvicitionAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.UnspentCriminalConvictions);
            return new WhosInControlFailedToPayBackFundsPage(_context);
        }
    }
}
