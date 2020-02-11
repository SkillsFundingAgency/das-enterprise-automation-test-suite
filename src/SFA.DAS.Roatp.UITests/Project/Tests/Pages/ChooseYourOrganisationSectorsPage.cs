using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ChooseYourOrganisationSectorsPage : RoatpBasePage
    {
        protected override string PageTitle => "Your sectors and employees";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ChooseYourOrganisationSectorsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public YourSectorsAndEmployeesPage SelectSectors()
        {
            SelectCheckboxByText("Digital");
            Continue();
            return new YourSectorsAndEmployeesPage(_context);
        }
    }
}


