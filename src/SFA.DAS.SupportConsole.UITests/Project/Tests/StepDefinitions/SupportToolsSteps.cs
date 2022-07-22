

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions;

[Binding]
public class SupportToolsSteps
{
    private readonly ScenarioContext _context;
    private readonly StepsHelper _stepsHelper;
    private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
    private readonly AccountsSqlDataHelper _accountsSqlDataHelper;
    private readonly string _hashedEmployerAccId;

    public SupportToolsSteps(ScenarioContext context)
    {
        _context = context;
        _stepsHelper = new StepsHelper(context);
        _commitmentsSqlDataHelper = context.Get<CommitmentsSqlDataHelper>();
        _accountsSqlDataHelper = context.Get<AccountsSqlDataHelper>();
        _hashedEmployerAccId = GetPublicHashedId();
    }

    [Given(@"the User is logged into Support Tools")]
    public void GivenTheUserIsLoggedIntoSupportTools() => _stepsHelper.ValidUserLogsinToSupportTools();

    [Given(@"Opens the Pause Utility")]
    [When(@"user opens Pause Utility")]
    public void WhenUserOpensPauseUtility() => new ToolSupportHomePage(_context).ClickPauseApprenticeshipsLink();

    [Given(@"Opens the Resume Utility")]
    public void GivenOpensTheResumeUtility() => new ToolSupportHomePage(_context).ClickResumeApprenticeshipsLink();

    [Given(@"Opens the Stop Utility")]
    public void GivenOpensTheStopUtility() => new ToolSupportHomePage(_context).ClickStopApprenticeshipsLink();


    [Given(@"Search for Apprentices using following criteria")]
    [Then(@"following filters should return the expected number of TotalRecords")]
    public void ThenFollowingFiltersShouldReturnTheExpectedNumberOfTotalRecords(Table table)
    {
        var filters = table.CreateSet<Filters>();
        int row = 1;

        foreach (var item in filters)
        {
            new SearchForApprenticeshipPage(_context, false)
                   .EnterEmployerName(item.EmployerName)
                   .EnterProviderName(item.ProviderName)
                   .EnterUkprn(item.Ukprn)
                   .EnterEndDate(item.EndDate)
                   .EnterULNorApprenticeName(item.Uln)
                   .SelectStatus(item.Status)
                   .ClickSubmitButton();

            var actualRecord = new SearchForApprenticeshipPage(_context, false).GetNumberOfRecordsFound();
            Assert.GreaterOrEqual(actualRecord, item.TotalRecords, $"Validate number of expected recordson row: {row}");
            row++;
        }
    }

    [When(@"User selects all records and click on Pause Apprenticeship button")]
    public void WhenUserSelectsAllRecordsAndClickOnPauseApprenticeshipButton() => SelectAllRecords().ClickPauseButton();

    [When(@"User selects all records and click on Resume Apprenticeship button")]
    public void WhenUserSelectsAllRecordsAndClickOnResumeApprenticeshipButton() => SelectAllRecords().ClickResumeButton();

    [When(@"User selects all records and click on Stop Apprenticeship button")]
    public void WhenUserSelectsAllRecordsAndClickOnStopApprenticeshipButton() => SelectAllRecords().ClickStopButton();
    
    private SearchForApprenticeshipPage SelectAllRecords()
    {
        var page = new SearchForApprenticeshipPage(_context, false);
        
        UpdateStatusInDb(page.GetULNsFromApprenticeshipTable());
        
        return page.ClickSubmitButton().SelectAllRecords();
    }

    [Then(@"User should be able to stop all the records")]
    public void ThenUserShouldBeAbleToStopAllTheRecords()
    {
        var ststusList = new StopApprenticeshipsPage(_context)
                                .ClickStopBtn()
                                .ValidateErrorMessage()
                                .EnterStopDateAndClickSetbutton()
                                .ValidateStopDateApplied()
                                .ClickStopBtn()
                                .GetStatusColumn();

        ValidateStopSuccessful(ststusList);
    }


    [Then(@"User should be able to pause all the live records")]
    public void ThenUserShouldBeAbleToPauseAllTheLiveRecords()
    {
        var ststusList = new PauseApprenticeshipsPage(_context)
                            .ClickPauseBtn()
                            .GetStatusColumn();

        ValidatePausedSuccessful(ststusList);
    }

    [Then(@"User should be able to resume all the paused records")]
    public void ThenUserShouldBeAbleToResumeAllThePausedRecords()
    {
        var ststusList = new ResumeApprenticeshipsPage(_context)
                           .ClickResumeBtn()
                           .GetStatusColumn();

        ValidateResumeSuccessful(ststusList);
    }

    [When(@"that account is suspended using bulk utility")]
    public void WhenThatAccountIsSuspendedUsingBulkUtility()
    {
        var status = _stepsHelper.ValidUserLogsinToSupportTools()
                            .ClickSuspendUserAccountsLink()
                            .EnterHashedAccountId(_hashedEmployerAccId)
                            .ClickSubmitButton()
                            .SelectAllRecords()
                            .ClickSuspendUserButton()
                            .ClicSuspendUsersbtn()
                            .GetStatusColumn();
       
        status.Where(x => x.Text == "Submitted successfully").FirstOrDefault();
    }

    [When(@"that account is reinstated using bulk utility")]
    public void WhenThatAccountIsReinstatedUsingBulkUtility()
    {
        string expectedStatusBefore = "Suspended " + DateTime.Now.ToString("dd/MM/yyyy");
        string expectedStatusAfter = "Submitted successfully";

        var actualStatusBefore = _stepsHelper.ValidUserLogsinToSupportTools(true)
                            .ClickReinstateUserAccountsLink()
                            .EnterHashedAccountId(_hashedEmployerAccId)
                            .ClickSubmitButton()
                            .SelectAllRecords()
                            .ClickReinstateUserButton()
                            .GetStatusColumn();

        actualStatusBefore.Where(x => x.Text == expectedStatusBefore).FirstOrDefault();

        var actualStatusAfter = new ReinstateUsersPage(_context).ClickReinstateUsersbtn().GetStatusColumn();

        actualStatusAfter.Where(x => x.Text == expectedStatusAfter).FirstOrDefault();
    }

    private void UpdateStatusInDb(List<IWebElement> UlnList)
    {
        int i = 0;
        foreach (var uln in UlnList)
        {
            if (i >= 0 && i < 4)
                _commitmentsSqlDataHelper.UpdateApprenticeshipStatus(uln.Text, 1);
            else if (i == 4 || i == 5 || i == 6)
                _commitmentsSqlDataHelper.UpdateApprenticeshipStatus(uln.Text, 2);
            else if (i == 7 || i == 8)
                _commitmentsSqlDataHelper.UpdateApprenticeshipStatus(uln.Text, 3);
            else
                _commitmentsSqlDataHelper.UpdateApprenticeshipStatus(uln.Text, 4);

            i++;
        }
    }

    private void ValidatePausedSuccessful(List<IWebElement> StatusList)
    {
        Assert.IsTrue(StatusList.Count == 10, "Validate total number of records");
        string todaysDate = DateTime.Now.ToString("dd/MM/yyyy");
        int i = 0;

        foreach (var status in StatusList)
        {
            if (i >= 0 && i < 4)
                Assert.That(status.Text == $"Submitted successfully {todaysDate}", $"failed at index [{i}]");
            else if (i == 4 || i == 5 || i == 6)
                Assert.That(status.Text == $"Paused {todaysDate} - Only Active record can be paused", $"failed at index [{i}]");
            else if (i == 7 || i == 8)
                Assert.That(status.Text == $"Stopped {todaysDate} - Only Active record can be paused", $"failed at index [{i}]");
            else
                Assert.That(status.Text == $"Completed - Only Active record can be paused", $"failed at index [{i}]");

            i++;
        }

    }

    private void ValidateResumeSuccessful(List<IWebElement> StatusList)
    {
        Assert.IsTrue(StatusList.Count == 10, "Validate total number of records");
        string todaysDate = DateTime.Now.ToString("dd/MM/yyyy");
        int i = 0;

        foreach (var status in StatusList)
        {
            if (i >= 0 && i < 4)
                Assert.That(status.Text == "Live - Only paused record can be activated" || status.Text == "WaitingToStart - Only paused record can be activated", "Resuming a Live Record", $"failed at index [{i}]");
            else if (i == 4 || i == 5 || i == 6)
                Assert.That(status.Text == $"Submitted successfully {todaysDate}", "Resuming a Paused Record", $"failed at index [{i}]");
            else if (i == 7 || i == 8)
                Assert.That(status.Text == $"Stopped {todaysDate} - Only paused record can be activated", "Resuming a Stopped Record", $"failed at index [{i}]");
            else
                Assert.That(status.Text == "Completed - Only paused record can be activated", "Resuming a Stopped Record", $"failed at index [{i}]");

            i++;
        }

    }

    private void ValidateStopSuccessful(List<IWebElement> StatusList)
    {
        Assert.IsTrue(StatusList.Count == 10, $"Validate total number of records. Expected: 10 | Actual {StatusList.Count}");
        string todaysDate = "01/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year.ToString("0000");
        string todaysDate2 = DateTime.Now.Month.ToString("00") + "/01/" + DateTime.Now.Year.ToString("0000");
        int i = 0;

        foreach (var status in StatusList)
        {
            if (i >= 0 && i < 7)
                Assert.IsTrue(status.Text == $"Submitted successfully {todaysDate}" || status.Text == $"Submitted successfully {todaysDate2}", $"validation failed at index [{i}]. Expected was [Submitted successfully {todaysDate}]  but actual value displayed is [{status.Text}]");
            else
                Assert.IsTrue(status.Text == "Apprenticeship must be Active or Paused. Unable to stop apprenticeship", $"validation failed at index [{i}]. Expected was [Apprenticeship must be Active or Paused. Unable to stop apprenticeship]  but actual value displayed is [{status.Text}]");

            i++;
        }
    }

    private string GetPublicHashedId()
    {
        var user = _context.GetUser<LevyUser>();
        return _accountsSqlDataHelper.GetPublicHashedId(user.Username);
    }

}