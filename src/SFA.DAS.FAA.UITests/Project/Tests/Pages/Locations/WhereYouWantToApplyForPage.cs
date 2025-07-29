using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.Locations;

public class WhereYouWantToApplyForPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Where you want to apply for";

    protected override By SubmitSectionButton => By.CssSelector("button.govuk-button[type='submit']");
}
