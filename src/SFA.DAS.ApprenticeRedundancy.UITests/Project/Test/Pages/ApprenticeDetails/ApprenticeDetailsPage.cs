using OpenQA.Selenium;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.Apprentice;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages
{
    public class ApprenticeDetailsPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "Apprentice details";

        #region Element Locators
        private By FirstName = By.Id("FirstName");
        private By LastName = By.Id("LastName");
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
        private By FeedbackYes = By.Id("ContactableForFeedback");
        private By LocationAndSectors = By.CssSelector(".govuk-checkboxes__item");
        private By PhoneNumber = By.Id("PhoneNumber");
        #endregion

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public Apprentice_CheckYourAnswersPage CompleteApprenticeDetails()
        {
            formCompletionHelper.EnterText(FirstName, apprenticeRedundancyDataHelper.FirstName);
            formCompletionHelper.EnterText(LastName, apprenticeRedundancyDataHelper.LastName);
            formCompletionHelper.EnterText(EmailAddress, apprenticeRedundancyDataHelper.Email);
            formCompletionHelper.EnterText(PhoneNumber, apprenticeRedundancyDataHelper.ContactNumber);
            var dobcalc = apprenticeRedundancyDataHelper.Dob(3);
            formCompletionHelper.EnterText(Day, dobcalc.Day);
            formCompletionHelper.EnterText(Month, dobcalc.Month);
            formCompletionHelper.EnterText(Year, dobcalc.Year);
            formCompletionHelper.SelectRadioOptionByLocator(UpdatesYes);
            formCompletionHelper.SelectRadioOptionByLocator(FeedbackYes);
            formCompletionHelper.EnterText(Postcode, apprenticeRedundancyDataHelper.Postcode);
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "East Midlands");
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "South West");   
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "Greater London");
            formCompletionHelper.EnterText(PreviousTraining, apprenticeRedundancyDataHelper.PreviousApprenticeshipTraining);
            formCompletionHelper.EnterText(Employer, apprenticeRedundancyDataHelper.Employer);
            formCompletionHelper.EnterText(EmployerLocation, apprenticeRedundancyDataHelper.Location);
            formCompletionHelper.EnterText(TrainingProvider, apprenticeRedundancyDataHelper.TrainingProvider);
            formCompletionHelper.EnterText(ApprenticeshipMonth, apprenticeRedundancyDataHelper.Months);
            formCompletionHelper.EnterText(ApprenticeshipYear, apprenticeRedundancyDataHelper.Years);
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "Business and administration");
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "Care services");
            formCompletionHelper.SelectCheckBoxByText(LocationAndSectors, "Education and childcare");
            Continue();
            return new Apprentice_CheckYourAnswersPage(_context);
        }
    }
}
