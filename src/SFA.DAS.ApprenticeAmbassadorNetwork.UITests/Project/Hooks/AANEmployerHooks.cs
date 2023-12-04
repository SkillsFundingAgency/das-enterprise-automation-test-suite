namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Hooks;

[Binding, Scope(Tag = "@aanemployer")]
public class AANEmployerHooks : AANBaseHooks
{
    public AANEmployerHooks(ScenarioContext context) : base(context)
    {

    }

    [BeforeScenario(Order = 31)]
    public void Navigate_Employer()
    {
        var account = "mpbd6m";

        if (context.ScenarioInfo.Tags.Contains("aanemployeronboardingreset")) account = "n7kry6";

        UrlConfig.AAN_Employer_BaseUrl = $"https://employer-aan.pp-eas.apprenticeships.education.gov.uk/accounts/{account}";

        tabHelper.GoToUrl(UrlConfig.AAN_Employer_BaseUrl);
    }
}
