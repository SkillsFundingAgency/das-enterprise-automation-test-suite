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
    public class EmployerWithholdProviderPaymentsPage(ScenarioContext context) : EmployerChangeTheTotalPricePage(context)
    {
        protected override string PageTitle => "Withhold provider payments";
        private static By PriceHintText => By.Id("apprenticeship-price-hint");
        private static By WithholdFuturePaymentsRadioButton => By.Id("freezePayments-true");
        internal static By ConfirmChangesButton => By.Id("buttonSubmitForm");


        public ApprenticeDetailsPage WithholdFuturePayments()
        {
            formCompletionHelper.SelectRadioOptionByLocator(WithholdFuturePaymentsRadioButton);
            formCompletionHelper.Click(ConfirmChangesButton);
            return new ApprenticeDetailsPage(context);
        }
    }
}
