using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Employer
{
    public class EmployerUnfreezeProviderPaymentsPage(ScenarioContext context) : EmployerFreezeProviderPaymentsPage(context)
    {
        protected override string PageTitle => "Unfreeze provider payments";
        private static By UnfreezeFuturePaymentsRadioButton => By.Id("UnfreezePayments-true");


        public ApprenticeDetailsPage UnfreezeFuturePayments()
        {
            formCompletionHelper.SelectRadioOptionByLocator(UnfreezeFuturePaymentsRadioButton);
            formCompletionHelper.Click(ConfirmChangesButton);
            return new ApprenticeDetailsPage(context);
        }
    }
}
