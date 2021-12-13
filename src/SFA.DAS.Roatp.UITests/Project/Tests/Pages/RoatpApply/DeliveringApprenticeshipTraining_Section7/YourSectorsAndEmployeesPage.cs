using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class YourSectorsAndEmployeesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Sectors and employee experience";

        public YourSectorsAndEmployeesPage(ScenarioContext context) : base(context) => VerifyPage();

        public ChooseYourOrganisationSectorsPage NavigateToChooseYourOrganisationSectors()
        {
            formCompletionHelper.ClickLinkByText("Choose sectors");
            return new ChooseYourOrganisationSectorsPage(_context);
        }

        public StandardsIntendToDeliverPage NavigateToMostExperiencedEmployeePage(string sector)
        {
            formCompletionHelper.ClickLinkByText(sector);
            return new StandardsIntendToDeliverPage(_context);
        }

        public ApplicationOverviewPage ContinueToApplicationOverviewPage()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}