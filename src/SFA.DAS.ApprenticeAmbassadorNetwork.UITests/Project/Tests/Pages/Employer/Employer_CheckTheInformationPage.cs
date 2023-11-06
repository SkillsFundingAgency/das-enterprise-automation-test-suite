

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class Employer_CheckTheInformationPage : AanBasePage
    {
        protected override string PageTitle => "Check the information you have provided before completing your registration";

        private By SubmitButton => By.Id("continue-button");
        private By ChangeLinkToWhatAreas => By.XPath("(//a[text()='Change'])[1]");
        private By ChangeLinkToReasonsForApply => By.XPath("(//a[text()='Change'])[2]");
        private By ChangeLinkToSupportNeeded => By.XPath("(//a[text()='Change'])[3]");
        private By ChangeLinkToPreviousEngagement => By.XPath("(//a[text()='Change'])[4]");

        public Employer_CheckTheInformationPage(ScenarioContext context) : base(context) => VerifyPage();

        public WhatAreasOfCountryYourOrganisationWorksInPage ChangeRegionLocationAndPreferences()
        {
            formCompletionHelper.Click(ChangeLinkToWhatAreas);
            return new WhatAreasOfCountryYourOrganisationWorksInPage(context);
        }

        public NetworkSupportAndNetworkJoinPage ChangeReasonsForApply()
        {
            formCompletionHelper.Click(ChangeLinkToReasonsForApply);
            return new NetworkSupportAndNetworkJoinPage(context);
        }

        public NetworkSupportAndNetworkJoinPage ChangeSupportNeeded()
        {
            formCompletionHelper.Click(ChangeLinkToSupportNeeded);
            return new NetworkSupportAndNetworkJoinPage(context);
        }

        public AreYouJoiningBecauseYouHaveEngagedPage ChangePreviousEngagement()
        {
            formCompletionHelper.Click(ChangeLinkToPreviousEngagement);
            return new AreYouJoiningBecauseYouHaveEngagedPage(context);
        }

        public RegistrationComplete_EmployerPage SubmitApplication()
        {
            formCompletionHelper.Click(SubmitButton);
            return new RegistrationComplete_EmployerPage(context);
        }
    }
}

