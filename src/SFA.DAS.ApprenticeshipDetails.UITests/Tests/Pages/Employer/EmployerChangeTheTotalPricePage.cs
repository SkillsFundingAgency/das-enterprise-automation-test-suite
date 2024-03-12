using OpenQA.Selenium;
using SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Employer
{
    public class EmployerChangeTheTotalPricePage(ScenarioContext context) : ChangePriceNegotiationAmountsPage(context)
    {
        protected override string PageTitle => "Change the total price";
        private static By PriceHintText => By.Id("apprenticeship-price-hint");
        private static By TotalPrice => By.Id("ApprenticeshipTotalPrice");
        private static By EffectiveFromDate_Day => By.Id("EffectiveFromDate_Day");
        private static By EffectiveFromDate_Month => By.Id("EffectiveFromDate_Month");
        private static By EffectiveFromDate_Year => By.Id("EffectiveFromDate_Year");
        private static By ReasonPriceChange => By.Id("ReasonForChangeOfPrice");
        protected override By ContinueButton => By.Id("buttonSubmitForm");

        public EmployerChangeOfPriceCheckYourChangesPage EnterValidChangeOfPriceDetails(string totalPrice, DateTime effectiveFrom, string reason)
        {
            formCompletionHelper.EnterText(TotalPrice, totalPrice);
            formCompletionHelper.EnterText(EffectiveFromDate_Day, effectiveFrom.Day);
            formCompletionHelper.EnterText(EffectiveFromDate_Month, effectiveFrom.Month);
            formCompletionHelper.EnterText(EffectiveFromDate_Year, effectiveFrom.Year);
            formCompletionHelper.EnterText(ReasonPriceChange, reason);

            formCompletionHelper.Click(ContinueButton);
            return new EmployerChangeOfPriceCheckYourChangesPage(context);
        }
    }
}
