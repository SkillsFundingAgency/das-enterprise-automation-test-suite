using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    class ReserveFundingToTrainAnApprenticePage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Reserve funding to train and assess an apprentice";

        public ReserveFundingToTrainAnApprenticePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
