using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditTransfersApprenticeDetailsPage : EditAppretinceNameDobAndReference
    {
        protected override string PageTitle => "Edit apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly EditedApprenticeDataHelper _dataHelper;
        #endregion


        protected override By FirstNameField => By.Id("FirstName");
        protected override By LastNameField => By.Id("LastName");
        protected override By DateOfBirthDay => By.Id("BirthDay");
        protected override By DateOfBirthMonth => By.Id("BirthMonth");
        protected override By DateOfBirthYear => By.Id("BirthYear");
        protected override By StartDateMonth => By.Id("StartMonth");
        protected override By StartDateYear => By.Id("StartYear");
        protected override By EndDateMonth => By.Id("EndMonth");
        protected override By EndDateYear => By.Id("EndYear");

        protected override By Reference => By.Id("Reference");

        protected override By UpdateDetailsButton => By.CssSelector(".govuk-button");

        public EditTransfersApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<EditedApprenticeDataHelper>();
        }

        public ReviewYourCohortPage EditApprenticePreApprovalAndSubmit()
        {
            EditApprenticeNameDobAndReference(_dataHelper.EmployerReference);
            return new ReviewYourCohortPage(_context);
        }
    }
}