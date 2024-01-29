global using OpenQA.Selenium;
global using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;
global using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;
global using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;
global using SFA.DAS.FAT_V2.UITests.Project.Helpers;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.ProviderLogin.Service.Project.Helpers;
global using SFA.DAS.UI.Framework.TestSupport;
global using System;
global using System.Collections.Generic;
global using TechTalk.SpecFlow;
using SFA.DAS.MailosaurAPI.Service;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project;

[Binding]
public class Hooks(ScenarioContext context)
{
    [BeforeScenario(Order = 21)]
    public void SetUpHelpers()
    {
        var emailDomain = context.Get<MailosaurApiHelper>().GetDomainName();

        var datahelper = new AedDataHelper(emailDomain);

        context.Set(datahelper);

        string email = datahelper.Email;

        context.Get<ObjectContext>().SetDebugInformation($"'{email}' is used");

        MailosaurApiHelper.UpdateInboxToDelete(email);
    }
}
