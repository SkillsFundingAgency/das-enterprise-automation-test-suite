using NUnit.Framework;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin;

public class AdminCreateEventBaseSteps(ScenarioContext context) : Admin_BaseSteps(context)
{
    protected SucessfullyPublisedEventPage sucessfullyPublisedEventPage;

    protected AanAdminCreateEventDatahelper aanAdminDatahelper = context.Get<AanAdminCreateEventDatahelper>();
    protected AanAdminStepsHelper stepsHelper = context.Get<AanAdminStepsHelper>();

    protected string AssertEventStatus(bool status)
    {
        var eventTitle = objectContext.GetAanEventTitle();

        var expected = status ? "True" : "False";

        var (id, isActive) = context.Get<AANSqlHelper>().GetEventId(eventTitle);

        Assert.That(isActive, Is.EqualTo(expected), $"'{id}', '{eventTitle}' - event Active status is not set as '{expected}' - Actual : '{isActive}'");

        return id;
    }

    protected SucessfullyPublisedEventPage SubmitInPersonEvent(bool guestSpeakers, bool isSchoolEvent) => SubmitEvent(EventFormat.InPerson, guestSpeakers, isSchoolEvent);

    protected SucessfullyPublisedEventPage SubmitOnlineEvent(bool guestSpeakers) => SubmitEvent(EventFormat.Online, guestSpeakers, false);

    protected SucessfullyPublisedEventPage SubmitHybridEvent(bool guestSpeakers, bool isSchoolEvent) => SubmitEvent(EventFormat.Hybrid, guestSpeakers, isSchoolEvent);

    protected CheckYourEventPage CheckYourEvent(EventFormat eventFormat, bool guestSpeakers, bool isSchoolEvent)
    {
        return stepsHelper.CheckYourEvent(eventFormat, guestSpeakers, isSchoolEvent);
    }

    private SucessfullyPublisedEventPage SubmitEvent(EventFormat eventFormat, bool guestSpeakers, bool isSchoolEvent)
    {
        return sucessfullyPublisedEventPage = stepsHelper.CheckYourEvent(eventFormat, guestSpeakers, isSchoolEvent).GoToEventPreviewPage(eventFormat).GoToCheckYourEventPage().SubmitEvent();
    }
}
