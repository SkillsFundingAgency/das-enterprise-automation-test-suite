namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public partial class CreateAnApprenticeshipAdvertOrVacancyPage : Raav2BasePage
    {
        #region Questions
        private string AdvertOrVacancysummary => isRaaV2Employer ? "1. Advert summary" : "1. Vacancy summary";
        private string AdvertOrVacancysummary_1 => isRaaV2Employer ? "Advert title" : "Vacancy title";
        private static string AdvertOrVacancysummary_2 => "Name of organisation";
        private static string AdvertOrVacancysummary_3 => "Training course";
        private static string Advertsummary_4 => "Training provider";
        private static string AdvertOrVacancysummary_5 => "Summary of the apprenticeship";
        private string AdvertOrVacancysummary_6 => isRaaV2Employer ? "About the apprenticeship" : "Tasks and training details";

        private string Employmentdetails => IsTraineeship ? "2. Placement details" : "2. Employment details";
        private string Employmentdetails_1 => isRaaV2Employer ? "Closing and start dates" : "Closing and start dates";
        private static string Employmentdetails_2 => "Duration and working hours";
        private static string Employmentdetails_3 => "Pay rate";
        private static string Employmentdetails_4 => "Number of positions";
        private static string Employmentdetails_5 => "Address";

        private string Skillsandqualifications => IsTraineeship ? "3. Requirements and Prospects" : (isRaaV2Employer ? "3. Requirements and prospects" : "3. Skills and qualifications");
        private static string Skillsandqualifications_1 => "Skills";
        private static string Skillsandqualifications_2 => "Qualifications";
        private static string Skillsandqualifications_3 => "Other things to consider";

        private static string Abouttheemployer => "4. About the employer";
        private string Abouttheemployer_1 => isRaaV2Employer ? "Name of employer on advert" : "Name of employer on vacancy";
        private static string Abouttheemployer_2 => "Employer information";
        private static string Abouttheemployer_3 => "Contact details";
        private string Abouttheemployer_4 => isRaaV2Employer ? "Website for applications" : "Application website";

        private static string Application => "5. Application";
        private static string Application_1 => "Questions for applicants";

        private string Checkandsubmityouradvert => IsTraineeship ? "5. Check and submit your vacancy" : (isRaaV2Employer ? "6. Check and submit your advert" : "6. Check and submit your vacancy");
        private string Checkandsubmityouradvert_1 => isRaaV2Employer ? "Check your answers and submit your advert" : "Check your answers and submit your vacancy";
        #endregion
    }
}
