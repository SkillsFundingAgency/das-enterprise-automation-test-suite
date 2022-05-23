namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public partial class CreateAnApprenticeshipAdvertOrVacancyPage : Raav2BasePage
    {
        #region Questions
        private string AdvertOrVacancysummary => isRaaV2Employer ? "1. Advert summary" : "1. Vacancy summary";
        private string AdvertOrVacancysummary_1 => isRaaV2Employer ? "Advert title" : "Vacancy title";
        private string AdvertOrVacancysummary_2 => "Name of organisation";
        private string AdvertOrVacancysummary_3 => "Training course";
        private string Advertsummary_4 => "Training provider";
        private string AdvertOrVacancysummary_5 => "Summary of the apprenticeship";
        private string AdvertOrVacancysummary_6 => isRaaV2Employer ? "About the apprenticeship" : "Tasks and training details";

        private string Employmentdetails => "2. Employment details";
        private string Employmentdetails_1 => isRaaV2Employer ? "Important dates" : "Closing and start dates";
        private string Employmentdetails_2 => "Duration and working hours";
        private string Employmentdetails_3 => "Pay rate";
        private string Employmentdetails_4 => "Number of positions";
        private string Employmentdetails_5 => "Address";

        private string Skillsandqualifications => "3. Skills and qualifications";
        private string Skillsandqualifications_1 => "Skills";
        private string Skillsandqualifications_2 => "Qualifications";
        private string Skillsandqualifications_3 => "Other things to consider";

        private string Abouttheemployer => "4. About the employer";
        private string Abouttheemployer_1 => isRaaV2Employer ? "Name of employer on advert" : "Name of employer on vacancy";
        private string Abouttheemployer_2 => "Employer information";
        private string Abouttheemployer_3 => "Contact details";
        private string Abouttheemployer_4 => isRaaV2Employer ? "Website for applications" : "Application website";

        private string Checkandsubmityouradvert => isRaaV2Employer ? "5. Check and submit your advert" : "5. Check and submit your vacancy";
        private string Checkandsubmityouradvert_1 => isRaaV2Employer ? "Check your answers and submit your advert" : "Check your answers and submit your vacancy";
        #endregion
    }
}
