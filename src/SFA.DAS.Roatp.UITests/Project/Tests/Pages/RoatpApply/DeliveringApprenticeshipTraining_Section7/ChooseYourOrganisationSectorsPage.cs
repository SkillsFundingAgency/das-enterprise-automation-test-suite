using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class ChooseYourOrganisationSectorsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What sectors will your organisation deliver apprenticeship training in?";

        public ChooseYourOrganisationSectorsPage(ScenarioContext context) : base(context) => VerifyPage();

        public YourSectorsAndEmployeesPage SelectSectors(string sector)
        {
            SelectCheckBoxByText(sector);
            Continue();
            return new YourSectorsAndEmployeesPage(context);
        }
    }
}