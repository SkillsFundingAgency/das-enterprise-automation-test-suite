namespace SFA.DAS.IdamsLogin.Service.Project;

public class DfeSignConfigurationSetupHelper
{
    private readonly ScenarioContext _context;

    public DfeSignConfigurationSetupHelper(ScenarioContext context) => _context = context;

    public void SetUpDfeSignConfiguration<T>(string key)
    {
        var configSection = _context.Get<IConfigSection>();

        var dfeSignInList = configSection.GetConfigSection<List<T>>(key);

        if (Configurator.IsVstsExecution)
        {
            var dfeSignInList1 = configSection.GetConfigSection<string>(key);

            dfeSignInList = JsonConvert.DeserializeObject<List<T>>(dfeSignInList1);
        }

        var dfeframeworkList = new FrameworkList<T>();

        dfeframeworkList.AddRange(dfeSignInList);

        _context.Set(dfeframeworkList);
    }
}