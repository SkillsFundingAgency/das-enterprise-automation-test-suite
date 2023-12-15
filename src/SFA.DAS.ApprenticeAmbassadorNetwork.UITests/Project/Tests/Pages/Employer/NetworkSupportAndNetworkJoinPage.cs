namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class NetworkSupportAndNetworkJoinPage : AanBasePage
    {
        protected override string PageTitle => "Why do you want to join the network?";

        private static By MeetOtherEmployerAmbassadorsCheckbox => By.Id("41");
        private static By ProjectManageCheckbox => By.Id("43");
        private static By BuildingApprenticeshipProfileCheckbox => By.Id("51");
        private static By IncreasingEngagementWithSchoolsAndCollegesCheckBox => By.Id("52");

        public NetworkSupportAndNetworkJoinPage(ScenarioContext context) : base(context) => VerifyPage();

        public AreYouJoiningBecauseYouHaveEngagedPage SelectMeetOtherEmployerAmbassador_BuildProfileAndContinue()
        {
            formCompletionHelper.SelectCheckbox(MeetOtherEmployerAmbassadorsCheckbox);
            formCompletionHelper.SelectCheckbox(BuildingApprenticeshipProfileCheckbox);
            Continue();
            return new AreYouJoiningBecauseYouHaveEngagedPage(context);
        }
        public Employer_CheckTheInformationPage Add_IncreasingEngagementWithSchoolsAndCollegesAndContinue()
        {
            formCompletionHelper.SelectCheckbox(IncreasingEngagementWithSchoolsAndCollegesCheckBox);
            Continue();
            return new Employer_CheckTheInformationPage(context);
        }
        public Employer_CheckTheInformationPage Add_ProjectManageAndContinue()
        {
            formCompletionHelper.SelectCheckbox(ProjectManageCheckbox);
            Continue();
            return new Employer_CheckTheInformationPage(context);
        }
    }
}

