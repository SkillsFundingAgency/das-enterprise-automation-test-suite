using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class YourSectorsAndEmployeesPage : RoatpBasePage
    {
        protected override string PageTitle => "Your sectors and employees";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public YourSectorsAndEmployeesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ChooseYourOrganisationSectorsPage NavigateToChooseYourOrganisationSectors()
        {
            formCompletionHelper.ClickLinkByText("Choose your organisation's sectors");
            return new ChooseYourOrganisationSectorsPage(_context);
        }

        public MostExperiencedEmployeePage NavigateToMostExperiencedEmployeePage()
        {
            formCompletionHelper.ClickLinkByText("Digital");
            return new MostExperiencedEmployeePage(_context);
        }

        public ApplicationOverviewPage ContinueToApplicationOverviewPage()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}


