using SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using static SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages.ConfirmSurveySentPage;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;

public class EarlyConnectStepsHelper(ScenarioContext context)
{
    public EarlyConnectHomePage GoToEarlyConnectHomePage() => new EarlyConnectHomePage(context).AcceptCookieAndAlert();
    public EarlyConnectHomePage GoToEarlyConnectNorthEastAdvisorPage() => new EarlyConnectHomePage(context).SelectNorthEast();
    public EarlyConnectHomePage GoToEarlyConnectLancashireAdvisorPage() => new EarlyConnectHomePage(context).SelectLancashire();
    public EarlyConnectHomePage GoToEarlyConnectLondonAdvisorPage() => new EarlyConnectHomePage(context).SelectLondon();
    public GetApprenticeshipAdviserPage GoToEarlyConnectEmailPage() => new GetApprenticeshipAdviserPage(context).GoToEmailAddressPage();
    public EmailAuthCodePage GoToAddUniqueEmailAddressPage() => new EmailAddressPage(context).EnterNewEmailAddress();
    public WhatsYourNamePage GoToCheckEmailAuthCodePage() => new EmailAuthCodePage(context).EnterValidAuthCode();
    public DateOfBirthPage GoToWhatYourNamePage() => new WhatsYourNamePage(context).EnterFirstAndLastNames();
    public PostcodePage GoToWhatIsYourDateOfBirthPage() => new DateOfBirthPage(context).EnterValidDateOfBirth();
    public TelephonePage GoToPostCodePage() => new PostcodePage(context).EnterValidPostcode();
    public AreasOfWorkInterestPage GoToWhatYourTelephonePage() => new TelephonePage(context).EnterValidTelephoneNumber();
    public SchoolCollegePage GoToAreasOfWorkInterestPage() => new AreasOfWorkInterestPage(context).SelectAnyAreaInterestToYou();
    public ApprenticeshipsLevelPage GoToEnterNameOfSchoolCollegePage() => new SchoolCollegePage(context).EnterInvalidSchoolOrCollegeName();
    public ApprenticeshipsLevelPage GoToNameOfSchoolCollegePage() => new SchoolCollegePage(context).SearchValidSchoolOrCollegeName();
    public HaveYouAppliedPage GoToApprencticeshipLevelPage() => new ApprenticeshipsLevelPage(context).SelectAnyApprenticeshipLevelInterestToYou();
    public AreaOfEnglandPage GoToHaveYouAppliedPage() => new HaveYouAppliedPage(context).SelectAnyPastApplications();
    public SupportPage GoToAreaOfEnglandPage() => new AreaOfEnglandPage(context).SelectYesForTheRightApprenticeship();
    public CheckYourAnswerPage GoToSupportPage() => new SupportPage(context).SelectAnySupportThatAppliesToYou();
    public ApplicantSurveySummitedPage GoToCheckYourAnswerPage() => new CheckYourAnswerPage(context).AcceptAndSubmitForm();
}
