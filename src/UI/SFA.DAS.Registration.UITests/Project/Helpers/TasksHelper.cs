
namespace SFA.DAS.Registration.UITests.Project.Helpers;

public class TasksHelper(ScenarioContext context)
{
    private readonly CommitmentsSqlHelper _commitmentsSqlHelper = context.Get<CommitmentsSqlHelper>();
    private readonly EmployerFinanceSqlHelper _employerFinanceSqlHelper = context.Get<EmployerFinanceSqlHelper>();
    private readonly TransferMatchingSqlDataHelper _transferMatchingSqlDataHelper = context.Get<TransferMatchingSqlDataHelper>();
    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    public int GetNumberOfApprenticesToReview()
    {
        var accountId = _objectContext.GetDBAccountId();
        return _commitmentsSqlHelper.GetNumberOfApprenticesToReview(accountId);
    }

    public int GetNumberOfCohortsReadyToReview()
    {
        var accountId = _objectContext.GetDBAccountId();
        return _commitmentsSqlHelper.GetNumberOfCohortsReadyToReview(accountId);
    }

    public int GetNumberOfTransferRequestToReview()
    {
        var accountId = _objectContext.GetDBAccountId();
        return _commitmentsSqlHelper.GetNumberOfTransferRequestToReview(accountId);
    }

    public int GetNumberOfPendingTransferConnections()
    {
        var accountId = _objectContext.GetDBAccountId();
        return _employerFinanceSqlHelper.GetNumberOfPendingTransferConnections(accountId);
    }

    public int GetNumberTransferPledgeApplicationsToReview()
    {
        var accountId = _objectContext.GetDBAccountId();
        return _transferMatchingSqlDataHelper.GetNumberTransferPledgeApplicationsToReview(accountId);
    }

    public static HomePage ClickViewApprenticeChangesLink(HomePage homePage, int numberOfChanges)
    {
        return homePage.ClickViewChangesForApprenticeChangesToReview(numberOfChanges)
            .GoToHomePage();
    }

    public static HomePage ClickViewCohortsToReviewLink(HomePage homePage, int numberOfChanges)
    {
        return homePage.ClickViewCohortsForCohortsReadyToReview(numberOfChanges)
            .GoToHomePage();
    }

    public static HomePage ClickViewDetailsForTransferRequestsLink(HomePage homePage)
    {
        return homePage.ClickViewDetailsForTransferRequests()
            .GoToHomePage();
    }

    public static HomePage ClickViewDetailsForTransferConnectionRequestsLink(HomePage homePage)
    {
        return homePage.ClickViewDetailsForTransferConnectionRequests()
            .GoToHomePage();
    }

    public static HomePage ClickTransferPledgeApplicationsLink(HomePage homePage, int numberOfChanges)
    {
        return homePage.ClickViewTransferPledgeApplications(numberOfChanges)
            .GoToHomePage();
    }
}
