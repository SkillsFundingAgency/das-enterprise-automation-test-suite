using SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using static SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages.ConfirmSurveySentPage;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;

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
    public WhatsYourNamePage GoToCheckEmailAuthCodePage()
    {
        return new EmailAuthCodePage(context).EnterValidAuthCode();
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

    public ApprenticeshipsLevelPage GoToEnterNameOfSchoolCollegePage()
    {
        return new SchoolCollegePage(context).EnterInvalidSchoolOrCollegeName();
    }

    public ApprenticeshipsLevelPage GoToNameOfSchoolCollegePage()
    {
        return new SchoolCollegePage(context).SearchValidSchoolOrCollegeName();
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
}
