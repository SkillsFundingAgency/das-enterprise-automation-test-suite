using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CancelEvent;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;

public class ManageAmbassadorsPage(ScenarioContext context) : SearchEventsBasePage(context)
{
    private static By CancelEventLink(string id) => By.CssSelector($"a[href='/events/{id}/cancel']");

    private static By CreateEventButton => By.CssSelector("#create-event");

    private static By MemberLink => By.XPath("(//a[text()='Alan Burns'])[1]");

    protected override string PageTitle => "Manage ambassadors";


    public MemberProfilePage AcessMember()
    {
        formCompletionHelper.Click(MemberLink);
        return new MemberProfilePage(context);
    }
    public new ManageAmbassadorsPage FilterAmbassadorByStatus_New()
    {
        base.FilterAmbassadorByStatus_New();
        return this;
    }

    public new ManageAmbassadorsPage FilterEventByAmbassadorStatus_Active()
    {
        base.FilterEventByAmbassadorStatus_Active();
        return this;
    }

    public new ManageAmbassadorsPage FilterEventByEventRegion_London()
    {
        base.FilterEventByEventRegion_London();
        return this;
    }


    public new ManageAmbassadorsPage ClearAllFilters()
    {
        base.ClearAllFilters();
        return this;
    }

    public new ManageAmbassadorsPage VerifyAMbassadorStatus_Published_New()
    {
        base.VerifyAMbassadorStatus_Published_New();
        return this;
    }

    public new ManageAmbassadorsPage VerifyAMbassadorStatus_Published_Active()
    {
        base.VerifyAMbassadorStatus_Published_Active();
        return this;
    }

    public new ManageAmbassadorsPage VerifyEventRegion_London_Filter()
    {
        base.VerifyEventRegion_London_Filter();
        return this;
    }

}
