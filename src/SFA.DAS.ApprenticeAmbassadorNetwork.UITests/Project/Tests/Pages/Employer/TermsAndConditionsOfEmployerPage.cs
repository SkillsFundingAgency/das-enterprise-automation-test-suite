namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class TermsAndConditionsOfEmployerPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Terms and conditions";

        private static By ConfirmAndContinueButton => By.Id("confirm-continue");

        public WhatAreasOfCountryYourOrganisationWorksInPage AcceptTermsAndConditions()
        {
            formCompletionHelper.Click(ConfirmAndContinueButton);
            return new WhatAreasOfCountryYourOrganisationWorksInPage(context);
        }
    }
}
