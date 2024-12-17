using OpenQA.Selenium;
using System.Linq.Expressions;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class SelectFundingPage(ScenarioContext context) : ApprovalsApprenticeBasePage(context)
    {
        protected override string PageTitle => "Select funding";
        protected override By PageHeader => By.ClassName("govuk-heading-l");
        protected override By ContinueButton => By.Id("submit-funding-type");

        public AddTrainingProviderDetailsPage SelectFundingType(FundingType fundingType)
        {
            switch (fundingType)
            {
                case FundingType.DirectTransferFundsFromConnection:
                    SelectRadioOptionByForAttribute("FundingType-1");
                    break;
                case FundingType.ReservedFunds:
                    SelectRadioOptionByForAttribute("FundingType-2");
                    break;
                case FundingType.ReserveNewFunds:
                    SelectRadioOptionByForAttribute("FundingType-3");
                    break;
                case FundingType.CurrentLevyFunds:
                    SelectRadioOptionByForAttribute("FundingType-4");
                    break;
                default:
                    break;
            }

            Continue();
            return new AddTrainingProviderDetailsPage(context);
        }


    }

    public enum FundingType
    {
        DirectTransferFundsFromConnection,
        ReservedFunds,
        ReserveNewFunds,
        CurrentLevyFunds
    }
}
