using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class SearchNetworkEventsPage : SearchEventsBasePage
{
    protected override string PageTitle => "Search network events";

    public SearchNetworkEventsPage(ScenarioContext context) : base(context) { }

    public EventPage ClickOnEvent((string id, DateTime startdate) eventLink)
    {
        FilterEventBy(eventLink.startdate);

        formCompletionHelper.ClickElement(FirstEventLink);

        var url = pageInteractionHelper.GetUrl();

        var guid = url.Split('/').ToList().Single(x => x.Count(c => c == '-') == 4);

        var eventUrl = url.Replace(guid, eventLink.id);

        tabHelper.GoToUrl(eventUrl);

        return new EventPage(context);
    }

    public new SearchNetworkEventsPage FilterEventByOneMonth()
    {
        base.FilterEventByOneMonth();
        return this;
    }

    public new SearchNetworkEventsPage FilterEventByEventFormat_InPerson()
    {
        base.FilterEventByEventFormat_InPerson();
        return this;
    }

    public new SearchNetworkEventsPage FilterEventByEventFormat_Online()
    {
        base.FilterEventByEventFormat_Online();
        return this;
    }

    public new SearchNetworkEventsPage FilterEventByEventFormat_Hybrid()
    {
        base.FilterEventByEventFormat_Hybrid();
        return this;
    }

    public new SearchNetworkEventsPage FilterEventByEventType_TrainingEvent()
    {
        base.FilterEventByEventType_TrainingEvent();
        return this;
    }

    public new SearchNetworkEventsPage FilterEventByEventRegion_London()
    {
        base.FilterEventByEventRegion_London();
        return this;
    }

    public new SearchNetworkEventsPage ClearAllFilters()
    {
        base.ClearAllFilters();
        return this;
    }
    public new SearchNetworkEventsPage VerifyEventType_TrainingEvent_Filter()
    {
        base.VerifyEventType_TrainingEvent_Filter();
        return this;
    }

    public new SearchNetworkEventsPage VerifyEventFormat_Inperson_Filter()
    {
        base.VerifyEventFormat_Inperson_Filter();
        return this;
    }

    public new SearchNetworkEventsPage VerifyEventFormat_Online_Filter()
    {
        base.VerifyEventFormat_Online_Filter();
        return this;
    }

    public new SearchNetworkEventsPage VerifyEventFormat_Hybrid_Filter()
    {
        base.VerifyEventFormat_Hybrid_Filter();
        return this;
    }

    public new SearchNetworkEventsPage VerifyEventRegion_London_Filter()
    {
        base.VerifyEventRegion_London_Filter();
        return this;
    }

}