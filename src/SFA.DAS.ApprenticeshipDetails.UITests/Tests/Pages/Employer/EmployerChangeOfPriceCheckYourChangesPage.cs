using OpenQA.Selenium;
using SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Employer
{
    public class EmployerChangeOfPriceCheckYourChangesPage(ScenarioContext context) : ChangePriceNegotiationAmountsPage(context)
    {
        protected override string PageTitle => "Check your changes before sending to the training provider";
        private static By SendButton => By.Id("buttonSubmitChangeOfPrice");
        public ApprenticeDetailsPage ClickSendButton()
        {
            formCompletionHelper.Click(SendButton);
            return new ApprenticeDetailsPage(context);
        }
    }
}
