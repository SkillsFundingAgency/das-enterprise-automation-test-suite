using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class WhosInControlBankruptInLastThreeYearsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "been made bankrupt in the last 3 years?";

        public WhosInControlBankruptInLastThreeYearsPage(ScenarioContext context) : base(context) => VerifyPage();

        public ProhibitionOrderFromTeachingRegulationAgencyPage SelectYesEnterInformationForBankruptAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.WhosInControlBankruptInLastThreeYears);
            return new ProhibitionOrderFromTeachingRegulationAgencyPage(_context);
        }
    }
}
