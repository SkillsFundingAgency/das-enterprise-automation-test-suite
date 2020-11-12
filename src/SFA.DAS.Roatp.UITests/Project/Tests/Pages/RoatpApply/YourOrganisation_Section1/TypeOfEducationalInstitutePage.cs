using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class TypeOfEducationalInstitutePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What type of educational institute is your organisation?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TypeOfEducationalInstitutePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public DescribeYourOrganisationPage SelectHigherEducationInstituteAndContinue()
        {
            SelectRadioOptionByText("Higher Education Institute");
            Continue();
            return new DescribeYourOrganisationPage(_context);
        }

        public AlreadyRegisteredWithEsfaPage SelectSixthFormCollegeAndContinue()
        {
            SelectRadioOptionByText("Sixth Form College");
            Continue();
            return new AlreadyRegisteredWithEsfaPage(_context);
        }

        public AlreadyRegisteredWithEsfaPage SelectAcademyAndContinue()
        {
            SelectRadioOptionByText("Academy");
            Continue();
            return new AlreadyRegisteredWithEsfaPage(_context);
        }

        public DescribeYourOrganisationPage SelectHigherEducationInstituteAndContinueForEmplopyer()
        {
            SelectRadioOptionByText("Higher Education Institute");
            Continue();
            return new DescribeYourOrganisationPage(_context);
        }
    }
}
