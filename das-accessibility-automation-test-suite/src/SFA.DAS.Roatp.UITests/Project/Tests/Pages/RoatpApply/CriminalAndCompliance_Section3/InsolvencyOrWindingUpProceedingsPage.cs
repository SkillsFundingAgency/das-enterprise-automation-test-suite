using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class InsolvencyOrWindingUpProceedingsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation been subject to insolvency or winding up proceedings in the last 3 years?";

        public InsolvencyOrWindingUpProceedingsPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage SelectYesEnterInformationForSubjectToInsolvencyOrWindingUpProceedingsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.InsolvencyOrWindingUpProceedings);
            return new ApplicationOverviewPage(context);
        }
    }
}