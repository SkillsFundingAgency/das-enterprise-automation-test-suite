namespace SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;

public abstract class EPAODataHelper
{
    public EPAODataHelper()
    {
        CurrentDay = DateTime.Now.Day;
        CurrentMonth = DateTime.Now.Month;
        CurrentYear = DateTime.Now.Year;
        RandomEmail = DateTimeExtension.GetDateTimeValue() + "@mailinator.com";
        RandomWebsiteAddress = "www.TEST" + DateTimeExtension.GetDateTimeValue() + ".com";
    }

    public int CurrentDay { get; }
    public int CurrentMonth { get; }
    public int CurrentYear { get; }
    public string RandomEmail { get; }
    public string RandomWebsiteAddress { get; }

    public static string AddressLine1 => "5";
    public static string AddressLine2 => "QuintonRoad";
    public static string AddressLine3 => "Cheylesmore House";
    public static string TownName => "Coventry";
    public static string CountyName => "Warwick";
    public static string PostCode => "CV1 2WT";

    public static string GetRandomNumber(int length) => RandomDataGenerator.GenerateRandomNumber(length);

    public static string GetRandomAlphabeticString(int length) => RandomDataGenerator.GenerateRandomAlphabeticString(length);
}