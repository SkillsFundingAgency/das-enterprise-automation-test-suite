using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AdminSteps
    {
        private readonly ScenarioContext _context;
        private readonly EPAOAdminDataHelper _ePAOAdminDataHelper;

        public AdminSteps(ScenarioContext context)
        {
            _context = context;
            _ePAOAdminDataHelper = context.Get<EPAOAdminDataHelper>();
        }

        [Then(@"the admin can search using organisation name")]
        public void ThenTheAdminCanSearchUsingOrganisationName() => SearchEpaoRegister(_ePAOAdminDataHelper.OrganisationName);

        [Then(@"the admin can search using organisation epao id")]
        public void ThenTheAdminCanSearchUsingOrganisationEpaoId() => SearchEpaoRegister(_ePAOAdminDataHelper.OrganisationEpaoId);

        [Then(@"the admin can search using organisation ukprn")]
        public void ThenTheAdminCanSearchUsingOrganisationUkprn() => SearchEpaoRegister(_ePAOAdminDataHelper.OrganisationUkprn);

        private void SearchEpaoRegister(string keyword) => GoToEpaoAdminHomePage().SearchEPAO().SearchForAnOrganisation(keyword).SelectAnOrganisation();

        private StaffDashboardPage GoToEpaoAdminHomePage()
        {
            new ServiceStartPage(_context).ClickStartNow().LoginToAccess1Staff();

            return new SignInPage(_context).SignInWithValidDetails();
        }
    }
}
