namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public partial class CreateAnApprenticeshipAdvertOrVacancyPage : RaaBasePage
    {
        #region Questions
        private string AdvertOrVacancysummary => isRaaEmployer ? "1. Advert summary" : "1. Vacancy summary";
        private string AdvertOrVacancysummary_1 => isRaaEmployer ? "Advert title" : "Vacancy title";
        private static string AdvertOrVacancysummary_2 => "Name of organisation";
        private static string AdvertOrVacancysummary_3 => "Training course";
        private static string Advertsummary_4 => "Training provider";
        private static string AdvertOrVacancysummary_5 => "Summary of the apprenticeship";
        private string AdvertOrVacancysummary_6 => isRaaEmployer ? "About the apprenticeship" : "Tasks and training details";

        private string Employmentdetails => "2. Employment details";
        private string Employmentdetails_1 => isRaaEmployer ? "Closing and start dates" : "Closing and start dates";
        private string Skillsandqualifications => "3. Requirements and prospects";
        private static string Skillsandqualifications_1 => "Skills";
        private static string FutureProspects_1 => "After this apprenticeship";

        private static string Abouttheemployer => "4. About the employer";
        private string Abouttheemployer_1 => isRaaEmployer ? "Name of employer on advert" : "Name of employer on vacancy";

        private static string Application => "5. Application questions";
        private static string Application_1 => "Application questions on Find an apprenticeship";

        private string Checkandsubmityouradvert => isRaaEmployer ? "6. Check and submit your advert" : "6. Check and submit your vacancy";
        private string Checkandsubmityouradvert_1 => isRaaEmployer ? "Check your answers and submit your advert" : "Check your answers and submit your vacancy";
        #endregion
    }
}
