

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class Employer_CheckTheInformationPage : AanBasePage
    {
        protected override string PageTitle => "Check the information you have provided before submitting your application";

        private By SubmitButton => By.Id("continue-button");
        private By ChangeLinkToWhatAreas => By.CssSelector("a[href='/accounts/v6gr7d/onboarding/regions']");
        private By ChangeLinkToReasonsForApply => By.CssSelector("a[href='/accounts/v6gr7d/onboarding/reason-to-join']");
        private By ChangeLinkToSupportNeeded => By.CssSelector("a[href='/accounts/v6gr7d/onboarding/support-needed']");
        private By ChangeLinkToPreviousEngagement => By.CssSelector("a[href='/accounts/v6gr7d/onboarding/previous-engagement']");

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

        public void SubmitApplication()
        {
            formCompletionHelper.Click(SubmitButton);
        }
    }
}

