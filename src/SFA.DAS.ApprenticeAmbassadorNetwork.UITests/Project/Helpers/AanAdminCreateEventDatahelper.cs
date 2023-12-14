using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers;

public class AanAdminCreateEventDatahelper : AanAdminCreateEventBaseDatahelper
{
    public AanAdminCreateEventDatahelper() : base()
    {

    }
}


public class AanAdminUpdateEventDatahelper : AanAdminCreateEventBaseDatahelper
{
    public AanAdminUpdateEventDatahelper() : base()
    {

    }
}

public abstract class AanAdminCreateEventBaseDatahelper
{
    public AanAdminCreateEventBaseDatahelper()
    {
        var date = RandomDataGenerator.GenerateRandomDate(DateTime.Now, DateTime.Now.AddDays(30));

        EventStartDateAndTime = date;

        var eventEndDateAndTime = date.AddHours(RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, 2)).AddMinutes(RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, 60));

        EventEndDateAndTime = eventEndDateAndTime;

        var name = RandomDataGenerator.GenerateRandomAlphabeticString(8);

        EventTitle = $"{name}_{date:ddMMMyyyy}_From{date:HHmm}To{eventEndDateAndTime:HHmm}_{date:fffff}";

        var location = RandomDataGenerator.GetRandomElementFromListOfElements(new System.Collections.Generic.List<string> { "London", "Coventry", "Harrow", "Manchester", "Yorkshire", "Temple" });

        EventInPersonLocation = location;

        var domain = $"TestAanEventIn{location}.com";

        EventOnlineLink = $"https://www.{name}{domain}";

        var school = RandomDataGenerator.GetRandomElementFromListOfElements(new System.Collections.Generic.List<string> { "Church", "Grange", "Primary", "Academy", "Catholic" });

        EventSchoolName = school;

        EventOrganiserName = name;

        EventOrganiserEmail = $"{name}@{domain}";

        EventAttendeesNo = $"{RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(5, 50)}";
    }

    public (EventFormat eventFormatEnum, string eventFormat) EventFormat { get; private set; }

    public string EventTitle { get; private set; }

    public string EventType { get; private set; }

    public string EventRegion { get; private set; }

    public DateTime EventStartDateAndTime { get; private set; }

    public DateTime EventEndDateAndTime { get; private set; }

    public string EventInPersonLocation { get; private set; }

    public string EventSchoolName { get; private set; }

    public string EventOnlineLink { get; private set; }

    public string EventOrganiserName { get; private set; }

    public string EventOrganiserEmail { get; private set; }

    public string EventAttendeesNo { get; private set; }

    public string EventOutline { get; init; } = RandomDataGenerator.GenerateRandomAlphabeticString(100);

    public string EventSummary { get; init; } = RandomDataGenerator.GenerateRandomAlphabeticString(100);

    public string GuestSpeakerName => RandomDataGenerator.GenerateRandomAlphabeticString(10);

    public string GuestSpeakerRole => RandomDataGenerator.GenerateRandomAlphabeticString(10);

    public void SetEventFormat(EventFormat eventFormat) => EventFormat = GetEventFormat(eventFormat);

    private static (EventFormat, string) GetEventFormat(EventFormat eventFormat) => (eventFormat, EventFormatToString(eventFormat));

    public void SetEventTypeAndRegion(string type, string region)
    {
        EventType = type;

        EventRegion = region;
    }

    private static string EventFormatToString(EventFormat eventFormat)
    {
        return true switch
        {
            bool _ when eventFormat == Helpers.EventFormat.InPerson => "InPerson",
            bool _ when eventFormat == Helpers.EventFormat.Online => "Online",
            _ => "Hybrid",
        };
    }

}