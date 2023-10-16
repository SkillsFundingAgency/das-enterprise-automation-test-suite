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
global using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
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
using Polly;


namespace SFA.DAS.EPAO.UITests.Project;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _context;
    private readonly DbConfig _config;
    private readonly TryCatchExceptionHelper _tryCatch;
    private EPAOAdminDataHelper _ePAOAdminDataHelper;
    private EPAOAdminSqlDataHelper _ePAOAdminSqlDataHelper;
    private EPAOApplySqlDataHelper _ePAOApplySqlDataHelper;

    public Hooks(ScenarioContext context)
    {
        _context = context;
        _tryCatch = context.Get<TryCatchExceptionHelper>();
        _config = context.Get<DbConfig>();
    }

    [BeforeScenario(Order = 32)]
    public void SetUpHelpers()
    {
        var objectContext = _context.Get<ObjectContext>();

        _ePAOApplySqlDataHelper = new EPAOApplySqlDataHelper(objectContext, _config);

        _context.Set(_ePAOApplySqlDataHelper);

        _ePAOAdminSqlDataHelper = new EPAOAdminSqlDataHelper(objectContext, _config);

        _context.Set(_ePAOAdminSqlDataHelper);

        _context.Set(new EPAOAssesmentServiceDataHelper());

        _context.Set(new EPAOApplyDataHelper());

        _context.Set(new EPAOApplyStandardDataHelper());

        _ePAOAdminDataHelper = new EPAOAdminDataHelper();

        _context.Set(_ePAOAdminDataHelper);

        _context.Set(new EPAOAdminCASqlDataHelper(objectContext, _config));
    }

    [BeforeScenario(Order = 33)]
    [Scope(Tag = "deleteorganisationstandards")]
    public void ClearStandards() => _ePAOAdminSqlDataHelper.DeleteOrganisationStandard(_ePAOAdminDataHelper.StandardCode, EPAOAdminDataHelper.OrganisationEpaoId);

    [BeforeScenario(Order = 34)]
    [Scope(Tag = "resetapplyuserorganisationid")]
    public void ResetApplyUserOrganisationId() => _ePAOApplySqlDataHelper.ResetApplyUserOrganisationId(_context.GetUser<EPAOApplyUser>().Username);

    [BeforeScenario(Order = 35)]
    [Scope(Tag = "resetstandardwithdrawal")]
    public void ResetStandardWithdrawalApplication() => _ePAOApplySqlDataHelper.ResetStandardWithdrawals(_context.GetUser<EPAOWithdrawalUser>().Username);

    [BeforeScenario(Order = 36)]
    [Scope(Tag = "resetregisterwithdrawal")]
    public void ResetRegisterWithdrawalApplication() => _ePAOApplySqlDataHelper.ResetRegisterWithdrawals(_context.GetUser<EPAOWithdrawalUser>().Username);

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
    public void CancelStandard() => _tryCatch.AfterScenarioException(() => new CancelStandardStepsHelper(_context).CancelYourStandard());
}
