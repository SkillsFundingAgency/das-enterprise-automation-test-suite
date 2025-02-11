namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;

public class AS_ApplyToStandardPage(ScenarioContext context) : EPAO_BasePage(context)
{
    protected override string PageTitle => "Apply to assess a standard";

    #region Links 

    #region Your policies and procedures
    private static string YourPolicies_01 => "Information commissioner's office registration";
    //private static string YourPolicies_02 => "Internal audit policy";
    //private static string YourPolicies_03 => "Public liability insurance";
    //private static string YourPolicies_04 => "Professional indemnity insurance";
    //private static string YourPolicies_05 => "Employers liability insurance";
    //private static string YourPolicies_06 => "Safeguarding policy";
    //private static string YourPolicies_07 => "Prevent agenda policy";
    //private static string YourPolicies_08 => "Conflict of interest policy";
    //private static string YourPolicies_09 => "Monitoring procedures";
    //private static string YourPolicies_10 => "Monitoring processes";
    //private static string YourPolicies_11 => "Complaints and appeals policy";
    //private static string YourPolicies_12 => "Fair access";
    //private static string YourPolicies_13 => "Consistency assurance";
    //private static string YourPolicies_14 => "Continuous quality assurance";
    #endregion

    //#region Your occupational competence
    //private static string YourOccupational_01 => "Engagement with trailblazers and employers";
    //private static string YourOccupational_02 => "Professional organisation membership";
    //#endregion

    //#region Your assessors
    //private static string YourAssessors_01 => "Number of assessors";
    //private static string YourAssessors_02 => "Assessment capacity";
    //private static string YourAssessors_03 => "Ability to deliver assessments";
    //#endregion

    //#region Your professional standards
    //private static string YourStandards_01 => "Recruitment and training";
    //private static string YourStandards_02 => "Skills and qualifications";
    //private static string YourStandards_03 => "Continuous professional development";
    //#endregion

    //#region Your end-point assessment delivery model
    //private static string YourDevileryModel_01 => "End-point assessment delivery model";
    //private static string YourDevileryModel_02 => "Outsourcing of end-point assessments";
    //private static string YourDevileryModel_03 => "Engaging with employers and training providers";
    //private static string YourDevileryModel_04 => "Managing conflicts of interest";
    //private static string YourDevileryModel_05 => "Assessment locations";
    //private static string YourDevileryModel_06 => "Providing services straight away";
    //private static string YourDevileryModel_07 => "Assessment methods";
    //private static string YourDevileryModel_08 => "Continuous resource development";
    //#endregion

    //#region Your end-point assessment competence
    //private static string YourAssesment_01 => "Secure IT infrastructure";
    //private static string YourAssesment_02 => "Assessment administration";
    //private static string YourAssesment_03 => "Assessment products and tools";
    //private static string YourAssesment_04 => "Assessment content";
    //private static string YourAssesment_05 => "Collation and confirmation of assessment outcomes";
    //private static string YourAssesment_06 => "Recording assessment results";
    //#endregion

    //#region Your online information
    //private static string YourOnline_01 => "Web address";
    //#endregion



    #endregion

    private static By ClickReturnToApplicationOverview => By.XPath("//a[@class='govuk-button']");

    public AS_InformationCommissionerPage AccessYourPolicies_01()
    {
        formCompletionHelper.ClickLinkByText(YourPolicies_01);
        return new(context);
    }

    public AS_ApplicationOverviewPage ReturnToApplicationOverview()
    {
        formCompletionHelper.Click(ClickReturnToApplicationOverview);
        return new(context);
    }
}