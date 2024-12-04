using SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using static SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages.ConfirmSurveySentPage;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers
{
    public class EarlyConnectStepsHelper(ScenarioContext context)
    {
        public EarlyConnectHomePage GoToEarlyConnectHomePage()
        {
            return new EarlyConnectHomePage(context).AcceptCookieAndAlert();
        }

        public EarlyConnectHomePage GoToEarlyConnectNorthEastAdvisorPage()
        {
            return new EarlyConnectHomePage(context).SelectNorthEast();
        }

        public EarlyConnectHomePage GoToEarlyConnectLancashireAdvisorPage()
        {
            return new EarlyConnectHomePage(context).SelectLancashire();
        }

        public GetApprenticeshipAdviserPage GoToEarlyConnectEmailPage()
        {
            return new GetApprenticeshipAdviserPage(context).GoToEmailAddressPage();
        }

        public EmailAuthCodePage GoToAddUniqueEmailAddressPage()
        {
            return  new EmailAddressPage(context).EnterNewEmailAddress();
        }

        public EmailAuthCodePage GoToAddAlreadyUsedEmailAddressPage()
        {
            return new EmailAddressPage(context).EnterAlreadyUsedEmailAddress();
        }

        public WhatsYourNamePage GoToCheckEmailAuthCodePage()
        {
            return new EmailAuthCodePage(context).EnterValidAuthCode();
        }

        public AlreadyCompletedFormPage GoToCheckUsedEmailAuthCodePage()
        {
            return new EmailAuthCodePage(context).EnterValidAuthCodeForUsedEmail();
        }

        public DateOfBirthPage GoToWhatYourNamePage()
        {
            return new WhatsYourNamePage(context).EnterFirstAndLastNames();
        }

        public PostcodePage GoToWhatIsYourDateOfBirthPage()
        {
            return new DateOfBirthPage(context).EnterValidDateOfBirth();
        }

        public TelephonePage GoToPostCodePage()
        {
            return new PostcodePage(context).EnterValidPostcode();
        }

        public AreasOfWorkInterestPage GoToWhatYourTelephonePage()
        {
            return new TelephonePage(context).EnterValidTelephoneNumber();
        }

        public SchoolCollegePage GoToAreasOfWorkInterestPage()
        {
            return new AreasOfWorkInterestPage(context).SelectAnyAreaInterestToYou();
        }

        public ApprenticeshipsLevelPage GoToNameOfSchoolCollegePage()
        {
            return new SchoolCollegePage(context).EnterValidSchoolOrCollegeName();
        }
        public HaveYouAppliedPage GoToApprencticeshipLevelPage()
        {
            return new ApprenticeshipsLevelPage(context).SelectAnyApprenticeshipLevelInterestToYou();
        }

        public AreaOfEnglandPage GoToHaveYouAppliedPage()
        {
            return new HaveYouAppliedPage(context).SelectAnyPastApplications();
        }

        public SupportPage GoToAreaOfEnglandPage()
        {
            return new AreaOfEnglandPage(context).SelectYesForTheRightApprenticeship();
        }
        public CheckYourAnswerPage GoToSupportPage()
        {
            return new SupportPage(context).SelectAnySupportThatAppliesToYou();
        }

        public ApplicantSurveySummitedPage GoToCheckYourAnswerPage()
        {
            return new CheckYourAnswerPage(context).AcceptAndSubmitForm();
        }

        public BecomeAnApprenticePage GoToBecomeAnApprenticePage()
        {
            return new EarlyConnectHomePage(context).SelectHowApprenticeshipsWorkLink();
        }

        public FindAnApprenticeshipPage GoToFindAnApprenticeshipPage()
        {
            return new EarlyConnectHomePage(context).SelectFindAnApprenticeshipLink();
        }

        // Back Navigation Step Helpers
        public WhatsYourNamePage GoBackToWhatYourNamePage()
        {
            return new DateOfBirthPage(context).SelectBackButton();
        }

        public DateOfBirthPage GoBackToWhatIsYourDateOfBirthPage()
        {
            return new PostcodePage(context).SelectBackButton();
        }

        public PostcodePage GoBackToPostCodePage()
        {
            return new TelephonePage(context).SelectBackButton();
        }

        public TelephonePage GoBackToWhatYourTelephonePage()
        {
            return new AreasOfWorkInterestPage(context).SelectBackButton();
        }

        public AreasOfWorkInterestPage GoBackToAreasOfWorkInterestPage()
        {
            return new SchoolCollegePage(context).SelectBackButton();
        }

        public SchoolCollegePage GoBackToNameOfSchoolCollegePage()
        {
            return new ApprenticeshipsLevelPage(context).SelectBackButton();
        }
        public ApprenticeshipsLevelPage GoBackToApprencticeshipLevelPage()
        {
            return new HaveYouAppliedPage(context).SelectBackButton();
        }

        public HaveYouAppliedPage GoBackToHaveYouAppliedPage()
        {
            return new AreaOfEnglandPage(context).SelectBackButton();
        }

        public AreaOfEnglandPage GoBackToAreaOfEnglandPage()
        {
            return new SupportPage(context).SelectBackButton();
        }
    }
}
