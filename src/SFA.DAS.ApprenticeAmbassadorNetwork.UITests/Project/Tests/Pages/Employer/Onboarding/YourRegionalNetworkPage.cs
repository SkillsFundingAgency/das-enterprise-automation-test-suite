using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer.Onboarding
{
    public class YourRegionalNetworkPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Your regional network";

        private static By ContinueButton => By.Id("continue");

        public Employer_CheckTheInformationPage ConfirmRegionalNetwork()
        {
            formCompletionHelper.ClickElement(ContinueButton);
            return new Employer_CheckTheInformationPage(context);
        }
    }
}
