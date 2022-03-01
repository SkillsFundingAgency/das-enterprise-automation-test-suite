using OpenQA.Selenium.Support.UI;
using SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers
{
    public class EmployerFrontDoorStepsHelper
    {
        private readonly ScenarioContext _context;

        public EmployerFrontDoorStepsHelper(ScenarioContext context) => _context = context;

        public EmployerFrontDoorHomePage GoToEmployerFrontDoorHomePage() {
            EmployerFrontDoorHomePage homePage = new EmployerFrontDoorHomePage(_context);
            homePage.AcceptCookieAndAlert();
            return homePage;
        }

        public ApprenticeshipsDetailsPage GoToApprenticeshipsDetailsPage()
        {
           ApprenticeshipsDetailsPage apprenticeshipsPage = new ApprenticeshipsDetailsPage(_context);
            apprenticeshipsPage.ApprenticeshipsScheme();
            return apprenticeshipsPage;
        }

        public TraineeshipsDetailsPage GotoTraineeshipsDetailsPage()
        {
            TraineeshipsDetailsPage traineeshipsPage = new TraineeshipsDetailsPage(_context);
            traineeshipsPage.TraineeshipsScheme();
            return traineeshipsPage;
        }

        public TLevelsDetailsPage GoToTLevelsDetailsPage()
        {
            TLevelsDetailsPage tLevelsPage = new TLevelsDetailsPage(_context);
            tLevelsPage.TLevelsScheme();
            return tLevelsPage;
        }

        public SWAPDetailsPage GoToSWAPDetailsPage()
        {
            SWAPDetailsPage swapPage = new SWAPDetailsPage(_context);
            swapPage.SWAPScheme();
            return swapPage;
        }

        public SkillsBootcampsDetailsPage GoToSkillsBootcampsDetailsPage()
        {
            SkillsBootcampsDetailsPage bootCampsPage = new SkillsBootcampsDetailsPage(_context);
            bootCampsPage.SkillsBootcampsScheme();
            return bootCampsPage;
        }

        public SupportedInternshipsDetailsPage GoToSupportedInternshipsDetailsPage()
        {
            SupportedInternshipsDetailsPage internShipsPage = new SupportedInternshipsDetailsPage(_context);
            internShipsPage.SupportedInternshipsScheme();
            return internShipsPage;
        }

        public CareLeaverDetailsPage GoToCareLeaverDetailsPage()
        {
            CareLeaverDetailsPage careLeaverPage = new CareLeaverDetailsPage(_context);
            careLeaverPage.CareLeaverScheme();
            return careLeaverPage;
        }

        public EmpPrisonersDetailsPage GoToEmpPrisonersDetailsPage()
        {
            EmpPrisonersDetailsPage empPrisonersPage = new EmpPrisonersDetailsPage(_context);
            empPrisonersPage.EmpPrisonersScheme();
            return empPrisonersPage;
        }

        public FreeCoursesDetailsPage GoToFreeCoursesDetailsPage()
        {
            FreeCoursesDetailsPage freeCoursesPage = new FreeCoursesDetailsPage(_context);
            freeCoursesPage.FreeCoursesScheme();
            return freeCoursesPage;
        }

        public FilterSchemesDetailsPage GoToFilterSchemesDetailsPage()
        {
            FilterSchemesDetailsPage filterSchemesPage = new FilterSchemesDetailsPage(_context);
            filterSchemesPage.FilterScheme();
            return filterSchemesPage;
        }
    }
}