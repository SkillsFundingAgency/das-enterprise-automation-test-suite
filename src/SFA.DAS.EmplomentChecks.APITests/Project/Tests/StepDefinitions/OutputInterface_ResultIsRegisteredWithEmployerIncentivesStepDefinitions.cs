using AutoFixture;
using FluentAssertions;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.EmploymentChecks.APITests.Project.Models;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Tests.StepDefinitions;

[Binding]
public class OutputInterface_ResultIsRegisteredWithEmployerIncentivesStepDefinitions(ScenarioContext context)
{
    private readonly EmploymentChecksSqlDbHelper _employmentChecksSqlDbHelper = context.Get<EmploymentChecksSqlDbHelper>();
    private readonly Helper _helper = context.Get<Helper>();
    private readonly string _checkType = context.ScenarioInfo.Title[..10];
    private EmploymentChecksDb _check;

    [Given(@"an employment check for an apprentice with '([^']*)', '([^']*)', '([^']*)'")]
    public async Task GivenAnEmploymentCheckForAnApprenticeWith(string status, bool? employed, string errorType)
    {
        var fixture = new Fixture();

        _check = fixture.Build<EmploymentChecksDb>()
            .Without(r => r.MessageSentDate)
            .With(r => r.Employed, employed)
            .With(r => r.ErrorType, errorType)
            .With(r => r.CheckType, _checkType)
            .With(r => r.RequestCompletionStatus, Enum.Parse(typeof(ProcessingCompletionStatus), status))
            .Create();

        await _employmentChecksSqlDbHelper.InsertData(_check);
    }

    [Then(@"employment check database record updated to indicate result has been published if '([^']*)'")]
    public async Task ThenEmploymentCheckDatabaseRecordUpdatedToIndicateResultHasBeenPublishedIf(bool shouldBeSent)
    {
        var check = await _employmentChecksSqlDbHelper.Get(_check.Id);

        if (shouldBeSent)
        {
            check.MessageSentDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMinutes(5), "Check result should have been sent");
        }
        else
        {
            check.MessageSentDate.Should().NotHaveValue();
        }
    }

    [When(@"apprentice employment check result is published")]
    public async Task WhenApprenticeEmploymentCheckResultIsPublished()
    {
        await _helper.EmploymentCheckOrchestrationHelper.StartResponseEmploymentChecksOrchestrator();
        await _helper.EmploymentCheckOrchestrationHelper.WaitUntilComplete();
    }

    [Then(@"employment check result has been processed by the Employer Incentives system")]
    public void ThenEmploymentCheckResultHasBeenProcessedByTheEmployerIncentivesSystem()
    {
        // 
    }
}
