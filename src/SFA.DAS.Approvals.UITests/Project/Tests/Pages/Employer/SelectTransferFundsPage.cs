using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
public class SelectTransferFundsPage(ScenarioContext context) : ApprovalsApprenticeBasePage(context)
{
    protected override string PageTitle => "Select transfer funds";
    private static By SelectContinueButton => By.Id("submit-levytransfer-connection");

    public AddTrainingProviderDetailsPage SelectTransferAndContinueToSelectProvider()
    {
        var transferRadioButtonLocator = By.Id(GenerateTransferId());
        formCompletionHelper.SelectRadioOptionByLocator(transferRadioButtonLocator);

        formCompletionHelper.ClickElement(SelectContinueButton);
        return new AddTrainingProviderDetailsPage(context);
    }

    private string GenerateTransferId()
    {
        var pledgeDetail = objectContext.GetPledgeDetail();
        var senderId = pledgeDetail.SenderHashedAccountId;
        var applicationId = objectContext.GetPledgeApplication(pledgeDetail.PledgeId);

        return $"LevyTransferConnection-{applicationId}|{senderId}";
    }
}