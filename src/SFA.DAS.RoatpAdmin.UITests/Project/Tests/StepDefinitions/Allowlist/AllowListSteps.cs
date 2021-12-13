using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.Allowlist
{
    [Binding]
    public class AllowListSteps
    {
        private readonly ScenarioContext _context;
        private AllowListPage _allowListPage;
        
        public AllowListSteps(ScenarioContext context) => _context = context;

        [When(@"the admin access the Allowlist")]
        public void WhenTheAdminAccessTheAllowlist() => _allowListPage = new StaffDashboardPage(_context).Add_UKPRN_Allowlist();

        [Then(@"the admin is able to add a ukprn to Allow list")]
        public void ThenTheAdminIsAbleToAddAUkprnToAllowList() => _allowListPage = _allowListPage.AddUkprnToAllowList();

        [Then(@"the admin is not able to add a ukprn exists in allow list")]
        public void ThenTheAdminIsNotAbleToAddAUkprnExistsInAllowList() => _allowListPage = _allowListPage.VerifyDuplicateUkrpnNotAdded();

        [Then(@"the admin is able to remove a ukprn from the allow list")]
        public void ThenTheAdminIsAbleToRemoveAUkprnFromTheAllowList() => _allowListPage.RemoveUkprnFromAllowlist().SelectYesRemoveUkprn();
    }
}
        
