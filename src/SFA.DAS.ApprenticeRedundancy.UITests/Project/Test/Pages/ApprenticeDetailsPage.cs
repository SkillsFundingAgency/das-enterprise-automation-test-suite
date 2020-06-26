using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages
{
    public class ApprenticeDetailsPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "Apprentice details";

        private By FullName = By.Id("FullName");
        private By EmailAddress = By.Id("Email");
        private By Day = By.Id("BirthDay");
        private By Month = By.Id("BirthMonth");
        private By Year = By.Id("BirthYear");
        private By UpdatesYes = By.Id("UpdatesWanted");
        private By Postcode = By.Id("PostCode");
        private By PreviousTraining = By.Id("PreviousTraining");
        private By Employer = By.Id("Employer");
        private By EmployerLocation = By.Id("EmployerLocation");
        private By TrainingProvider = By.Id("TrainingProvider");
        private By ApprenticeshipMonth = By.Id("LeftOnApprenticeshipMonths");
        private By ApprenticeshipYear = By.Id("LeftOnApprenticeshipYears");
        private By JobseekerAllowance = By.Id("ClaimingJobseekersAllowance");
        private By LocationAndSectors = By.CssSelector(".govuk-checkboxes__item");
        private By PhoneNumber = By.Id("PhoneNumber");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public void CompleteApprenticeDetails()
        {
            formCompletionHelper.EnterText(FullName, apprenticeRedundancyDataHelper.FullName);
            formCompletionHelper.EnterText(EmailAddress, apprenticeRedundancyDataHelper.Email);
            formCompletionHelper.EnterText(PhoneNumber, apprenticeRedundancyDataHelper.ContactNumber);
            formCompletionHelper.EnterText(Day,apprenticeRedundancyDataHelper.Day);
            formCompletionHelper.EnterText(Month, apprenticeRedundancyDataHelper.Month);
            formCompletionHelper.EnterText(Year, apprenticeRedundancyDataHelper.Year);
            formCompletionHelper.SelectRadioOptionByLocator(UpdatesYes);
            formCompletionHelper.EnterText(Postcode, apprenticeRedundancyDataHelper.Postcode);
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "East Midlands");
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "South West");   
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "Greater London");
            formCompletionHelper.EnterText(PreviousTraining, apprenticeRedundancyDataHelper.PreviousApprenticeshipTraining);
            formCompletionHelper.EnterText(Employer, apprenticeRedundancyDataHelper.Employer);
            formCompletionHelper.EnterText(EmployerLocation, apprenticeRedundancyDataHelper.Location);
            formCompletionHelper.EnterText(TrainingProvider, apprenticeRedundancyDataHelper.TrainingProvider);
            var dobcalc = apprenticeRedundancyDataHelper.Dob(2);
            formCompletionHelper.EnterText(ApprenticeshipMonth, dobcalc.Month);
            formCompletionHelper.EnterText(ApprenticeshipYear, dobcalc.Year);
            formCompletionHelper.SelectRadioOptionByLocator(JobseekerAllowance);
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "Business, Administration and Law");
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "Health, Public Services and Care");
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors,"Education and Training");
            Continue();
        }
    }
}
