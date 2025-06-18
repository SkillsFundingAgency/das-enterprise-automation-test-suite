using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAEmployer.UITests.Project.Tests.Pages.Employer
{
    public class ManageYourEmailsPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Manage your emails";
    }
}
