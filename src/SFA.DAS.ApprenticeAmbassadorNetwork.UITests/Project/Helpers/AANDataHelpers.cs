using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers;

public record AANTestData
{
    public string LarsCode;
    public string StandardName;
    public string Venue;
}

public class AANDataHelpers
{
    public const string LocationName = "Test Demo Automation Venue";
    public string VenueName { get; init; } = LocationName;
    public string NewVenueName { get; init; } = "New Venue Test Demo Automation Venue";
    public string Standard_ActuaryLevel7 { get; init; } = "Actuary (Level 7)";
    public string PostCode { get; init; } = "Tw14 9py";
    public string Website { get; init; } = "www.company.co.uk";
    public string JobTitle { get; init; } = "SoftwareTESTER";
    public string NewJobTitle { get; init; } = "AutomationSoftwareTESTER";
    public string UpdatedWebsite { get; init; } = "www.123company.co.uk";
    public string ContactWebsite { get; init; } = "www.companycontact.co.uk";
    public string AddressLine1 { get; init; } = "Automation Address line one";
    public string AddressLine2 { get; init; } = "Automation Address line two";
    public string County { get; init; } = "Automation Address County";
    public string Town { get; init; } = "Automation Address Town";
    public string ContactNumber { get; init; } = RandomDataGenerator.GenerateRandomNumber(12);
    public string UpdateProviderDescriptionText { get; init; } = RandomDataGenerator.GenerateRandomAlphanumericString(20);
}


public class AanAdminDatahelper
{
    public AanAdminDatahelper()
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

        EventSchoolName = location;

        EventOrganiserName = name;

        EventOrganiserEmail = $"{name}@{domain}";

        EventAttendeesNo = $"{RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(5, 50)}";
    }
    
    public string EventTitle { get; private set; }

    public (EventFormat eventFormatEnum, string eventFormat) EventFormat { get; private set; }

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

    public void SetEventFormat(EventFormat eventFormat)
    {
        EventFormat = (eventFormat, GetEventFormat(eventFormat));
    }

    private static string GetEventFormat(EventFormat eventFormat)
    {
        return true switch
        {
            bool _ when eventFormat == Helpers.EventFormat.InPerson => "InPerson",
            bool _ when eventFormat == Helpers.EventFormat.Online => "Online",
            _ => "Hybrid",
        };
    }

}