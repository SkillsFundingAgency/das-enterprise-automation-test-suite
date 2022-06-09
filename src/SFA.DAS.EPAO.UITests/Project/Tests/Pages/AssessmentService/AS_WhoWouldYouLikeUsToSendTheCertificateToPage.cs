namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_WhoWouldYouLikeUsToSendTheCertificateToPage: EPAOAssesment_BasePage
{
    protected override string PageTitle => "Who would you like us to send the certificate to?";
    
    public AS_WhoWouldYouLikeUsToSendTheCertificateToPage (ScenarioContext context) : base(context) => VerifyPage();

     public AS_SearchEmployerAddressPage ClickAprenticeRadioButton()
     {
        SelectRadioOptionByText("Apprentice");
         Continue();
         return new AS_SearchEmployerAddressPage(context);
     }

     public AS_SearchEmployerOrAddressPage ClickEmployerRadioButton()
     {
        SelectRadioOptionByText("Employer");
        Continue();
         return new AS_SearchEmployerOrAddressPage(context);
     }        
}