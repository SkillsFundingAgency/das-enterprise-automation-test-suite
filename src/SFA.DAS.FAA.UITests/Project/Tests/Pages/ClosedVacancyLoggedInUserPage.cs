using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class ClosedVacancyLoggedInUserPage(ScenarioContext context) : FAABasePage(context)
    {
        protected override string PageTitle => context["ClosedVacancyPageTitle"]?.ToString();

    }
}
