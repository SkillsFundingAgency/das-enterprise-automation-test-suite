global using NUnit.Framework;
global using OpenQA.Selenium;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.EPAO.UITests.Project.Helpers;
global using SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;
global using SFA.DAS.EPAO.UITests.Project.Helpers.SqlHelpers;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.ApplicationAccuracySubSection;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.AuthoriserDetailsSubSection;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.MandatoryExclusionSubSection;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.EPAOStandardCancellationPages;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.FinancialHealthAssessmentSection;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;
global using SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.Login.Service;
global using SFA.DAS.Login.Service.Project.Helpers;
global using SFA.DAS.TestDataExport.Helper;
global using SFA.DAS.UI.Framework;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.UI.FrameworkHelpers;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text.RegularExpressions;
global using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project;

[Binding]
public class Hooks(ScenarioContext context)
{
    private readonly DbConfig _config = context.Get<DbConfig>();
    private readonly TryCatchExceptionHelper _tryCatch = context.Get<TryCatchExceptionHelper>();
    private EPAOAdminDataHelper _ePAOAdminDataHelper;
    private EPAOAdminSqlDataHelper _ePAOAdminSqlDataHelper;
    private EPAOApplySqlDataHelper _ePAOApplySqlDataHelper;

    [BeforeScenario(Order = 32)]
    public void SetUpHelpers()
    {
        var objectContext = context.Get<ObjectContext>();

        _ePAOApplySqlDataHelper = new EPAOApplySqlDataHelper(objectContext, _config);

        context.Set(_ePAOApplySqlDataHelper);

        _ePAOAdminSqlDataHelper = new EPAOAdminSqlDataHelper(objectContext, _config);

        context.Set(_ePAOAdminSqlDataHelper);

        context.Set(new EPAOAssesorCreateUserDataHelper());

        context.Set(new EPAOAssesmentServiceDataHelper());

        context.Set(new EPAOApplyDataHelper());

        context.Set(new EPAOApplyStandardDataHelper());

        _ePAOAdminDataHelper = new EPAOAdminDataHelper();

        context.Set(_ePAOAdminDataHelper);

        context.Set(new EPAOAdminCASqlDataHelper(objectContext, _config));
    }

    [BeforeScenario(Order = 33)]
    [Scope(Tag = "deleteorganisationstandards")]
    public void ClearStandards() => _ePAOAdminSqlDataHelper.DeleteOrganisationStandard(_ePAOAdminDataHelper.StandardCode, EPAOAdminDataHelper.OrganisationEpaoId);

    [BeforeScenario(Order = 34)]
    [Scope(Tag = "resetapplyuserorganisationid")]
    public void ResetApplyUserOrganisationId() => _ePAOApplySqlDataHelper.ResetApplyUserOrganisationId(context.GetUser<EPAOApplyUser>().Username);

    [BeforeScenario(Order = 35)]
    [Scope(Tag = "resetstandardwithdrawal")]
    public void ResetStandardWithdrawalApplication() => _ePAOApplySqlDataHelper.ResetStandardWithdrawals(context.GetUser<EPAOWithdrawalUser>().Username);

    [BeforeScenario(Order = 36)]
    [Scope(Tag = "resetregisterwithdrawal")]
    public void ResetRegisterWithdrawalApplication() => _ePAOApplySqlDataHelper.ResetRegisterWithdrawals(context.GetUser<EPAOWithdrawalUser>().Username);

    [BeforeScenario(Order = 37)]
    [Scope(Tag = "deleteorganisationstandardversion")]
    public void ClearOrgganisationStandardVersion() => _ePAOApplySqlDataHelper.DeleteOrganisationStandardVersion();

    [AfterScenario(Order = 32)]
    [Scope(Tag = "deleteorganisationcontact")]
    public void ClearContact() => _tryCatch.AfterScenarioException(() => _ePAOAdminSqlDataHelper.DeleteContact(_ePAOAdminDataHelper.Email));

    [AfterScenario(Order = 33)]
    [Scope(Tag = "deleteorganisation")]
    public void ClearOrganisation() => _tryCatch.AfterScenarioException(() => _ePAOAdminSqlDataHelper.DeleteOrganisation(_ePAOAdminDataHelper.NewOrganisationUkprn));

    [AfterScenario(Order = 34)]
    [Scope(Tag = "makeorganisationlive")]
    public void MakeOrganisationLive() => _tryCatch.AfterScenarioException(() => _ePAOAdminSqlDataHelper.UpdateOrgStatusToLive(EPAOAdminDataHelper.MakeLiveOrganisationEpaoId));

    [AfterScenario(Order = 18)]
    [Scope(Tag = "cancelstandard")]
    public void CancelStandard() => _tryCatch.AfterScenarioException(() => new CancelStandardStepsHelper(context).CancelYourStandard());
}
