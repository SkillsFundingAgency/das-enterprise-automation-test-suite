namespace SFA.DAS.RAA.APITests.Project;

public abstract class Raa_Outer_ApiAuthTokenConfig
{
    public string Hashed_AccountId { get; set; }

    public string Ukprn { get; set; }

    public string ApiKey { get; set; }

    public string InvalidApiKey { get; set; }

    public string DisplayAdvertApiKey { get; set; }

    public string VacancyReference { get; set; }
}

public class Raa_Emp_Outer_ApiAuthTokenConfig : Raa_Outer_ApiAuthTokenConfig
{

}

public class Raa_Pro_Outer_ApiAuthTokenConfig : Raa_Outer_ApiAuthTokenConfig
{
   
}