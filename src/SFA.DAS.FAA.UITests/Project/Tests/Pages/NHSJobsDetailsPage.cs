using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class NHSJobsDetailsPage(ScenarioContext context) : FAASignedInLandingBasePage(context) 
    {
        protected override By PageHeader => By.CssSelector("h1[class='govuk-heading-l govuk-!-margin-bottom-8']");
        protected override string PageTitle => "See more details about this apprenticeship on NHS Jobs";
    }
}
