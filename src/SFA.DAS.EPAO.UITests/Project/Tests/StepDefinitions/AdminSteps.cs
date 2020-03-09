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
        public AdminSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Then(@"the admin can search using organisation name")]
        public void ThenTheAdminCanSearchUsingOrganisationName()
        {
            GoToEpaoAdminHomePage();
        }


        private EpaoAdminHomePage GoToEpaoAdminHomePage()
        {
            new ServiceStartPage(_context).ClickStartNow().LoginToAccess1Staff();

            return new SignInPage(_context).SignInWithValidDetails();
        }
    }
}
