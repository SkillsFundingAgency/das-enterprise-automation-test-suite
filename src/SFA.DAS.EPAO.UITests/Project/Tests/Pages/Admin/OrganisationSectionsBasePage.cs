namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public abstract class OrganisationSectionsBasePage(ScenarioContext context) : EPAOAdmin_BasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    protected OrganisationDetailsPage ReturnToOrganisationDetailsPage(Action action)
    {
        action();
        return new(context);
    }
}
