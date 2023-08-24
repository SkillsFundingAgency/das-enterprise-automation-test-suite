using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class TermsAndConditionsOfEmployerPage : AanBasePage
    {
        protected override string PageTitle => "Terms and Conditions";

        private By ConfirmAndContinueButton => By.Id("confirm-continue");

        public TermsAndConditionsOfEmployerPage(ScenarioContext context) : base(context) => VerifyPage();

        public WhatAreasOfCountryYourOrganisationWorksInPage AcceptTermsAndConditions()
        {
            formCompletionHelper.Click(ConfirmAndContinueButton);
            return new WhatAreasOfCountryYourOrganisationWorksInPage(context);
        }
    }
}
