using OpenQA.Selenium;
using SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Employer
{
    public class EmployerFreezeProviderPaymentsPage(ScenarioContext context) : EmployerChangeTheTotalPricePage(context)
    {
        protected override string PageTitle => "Freeze provider payments";

        private static By PriceHintText => By.Id("apprenticeship-price-hint");
        private static By FreezeFuturePaymentsRadioButton => By.Id("freezePayments-true");
        private static By ConfirmChangesButton => By.Id("buttonSubmitForm");


        public ApprenticeDetailsPage FreezeFuturePayments()
        {
            formCompletionHelper.SelectRadioOptionByLocator(FreezeFuturePaymentsRadioButton);
            formCompletionHelper.Click(ConfirmChangesButton);
            return new ApprenticeDetailsPage(context);
        }
    }
}
