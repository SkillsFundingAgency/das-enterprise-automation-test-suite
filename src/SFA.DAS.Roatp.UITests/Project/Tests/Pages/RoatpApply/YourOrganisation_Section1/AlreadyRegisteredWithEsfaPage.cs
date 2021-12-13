using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class AlreadyRegisteredWithEsfaPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Is your organisation";

        public AlreadyRegisteredWithEsfaPage(ScenarioContext context) : base(context) => VerifyPage();

        public DescribeYourOrganisationPage SelectYesForOrgAlreadyRegisteredAndContinueRouteEmployer()
        {
            SelectYesAndContinue();
            return new DescribeYourOrganisationPage(context);
        }
        public DescribeYourOrganisationPage SelectYesForOrgAlreadyRegisteredAndContinue()
        {
            SelectYesAndContinue();
            return new DescribeYourOrganisationPage(context);
        }
        public DescribeYourOrganisationPage SelectNoForOrgAlreadyRegisteredAndContinue()
        {
            SelectNoAndContinue();
            return new DescribeYourOrganisationPage(context);
        }
    }
}
