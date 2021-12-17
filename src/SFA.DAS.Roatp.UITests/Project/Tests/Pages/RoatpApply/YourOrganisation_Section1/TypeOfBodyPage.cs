using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class TypeOfBodyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What type of public body is your organisation?";

        public TypeOfBodyPage(ScenarioContext context) : base(context) => VerifyPage();

        public DescribeYourOrganisationPage SelectGovernmentDepartmentAndContinue()
        {
            SelectRadioOptionByText("Government department");
            Continue();
            return new DescribeYourOrganisationPage(context);
        }
    }
}
