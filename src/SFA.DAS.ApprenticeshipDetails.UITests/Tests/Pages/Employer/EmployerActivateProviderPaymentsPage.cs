using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Employer
{
    public class EmployerActivateProviderPaymentsPage(ScenarioContext context) : EmployerWithholdProviderPaymentsPage(context)
    {
        protected override string PageTitle => "Activate provider payments";
        private static By ActivateFuturePaymentsRadioButton => By.Id("UnfreezePayments-true");


        public ApprenticeDetailsPage ActivateFuturePayments()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ActivateFuturePaymentsRadioButton);
            formCompletionHelper.Click(ConfirmChangesButton);
            return new ApprenticeDetailsPage(context);
        }
    }
}
