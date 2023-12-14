namespace SFA.DAS.DfeAdmin.Service.Project.Helpers;

public class DfeSignConfigurationSetupHelper(ScenarioContext context)
{
    public void SetUpDfeSignConfiguration<T>(string key)
    {
        var configSection = context.Get<IConfigSection>();

        var dfeSignInList = configSection.GetConfigSection<List<T>>(key);

        if (Configurator.IsVstsExecution)
        {
            var dfeSignInList1 = configSection.GetConfigSection<string>(key);

            dfeSignInList = JsonConvert.DeserializeObject<List<T>>(dfeSignInList1);
        }

        var dfeframeworkList = new FrameworkList<T>();

        dfeframeworkList.AddRange(dfeSignInList);

        context.Set(dfeframeworkList);
    }
}